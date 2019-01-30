using InfoMallWebService.Data;
using InfoMallWebService.Dtos;
using InfoMallWebService.Models;
using InfoMallWebService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoMallWebService.Repository
{
	public class ContentImageRepository : IContentImageRepository
	{
		private readonly ApplicationDbContext _ctx;
		private readonly IImageService _imgService;
		private readonly IHostingEnvironment _env;
		private readonly ILogger<ContentImageRepository> _logger;
		public ContentImageRepository(ApplicationDbContext context, 
			IImageService imageService, 
			ILogger<ContentImageRepository> logger, 
			IHostingEnvironment env)
		{
			_ctx = context;
			_imgService = imageService;
			_env = env;
			_logger = logger;
		}

		public bool AddContentImage(ContentImageDto contentImage)
		{
			if (contentImage.File != null && !string.IsNullOrEmpty(contentImage.Description))
			{
				string path = _imgService.CreateImage(contentImage.File, _env);
				if (!string.IsNullOrEmpty(path))
				{
					ContentImage content = new ContentImage
					{
						CarImagePath = path,
						Description = contentImage.Description,
						ExtraData = contentImage.ExtraData,
						ContentForTabId = contentImage.ContentForTabId
					};

					try
					{
						_ctx.ContentImages.Add(content);
						_ctx.SaveChanges();
						return true;
					}
					catch (DbUpdateException ex)
					{
						_logger.LogInformation($"Cannot add image {ex.Message}");
					}
				}
			}
			return false;
		}

		public void AddContentImages(int contentForTabId, List<ContentImageDto> contentImages)
		{
			try
			{
				IEnumerable<ContentImage> contents = contentImages.Select(cI => new ContentImage
				{
					Description = cI.Description,
					ExtraData = cI.ExtraData,
					CarImagePath = _imgService.CreateImage(cI.File, _env),
					ContentForTabId = contentForTabId
				});

				_ctx.ContentImages.AddRange(contents);
				_ctx.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Content Image could not be saved because of {ex.Message}");
			}

		}

		public string EditContentImage(ContentImageDto contentImage)
		{
			if (ContentImageExists(contentImage.ContentImageId))
			{
				string imagePath = _imgService.EditImage(contentImage.File, contentImage.OldImage, _env);

				ContentImage contentImageToEdit = _ctx.ContentImages.Where(cI => cI.ContentImageId == contentImage.ContentImageId)
											.Select(cI => new ContentImage
											{
												Description = contentImage.Description ?? cI.Description,
												ExtraData = contentImage.ExtraData ?? cI.ExtraData,
												CarImagePath = imagePath ?? cI.CarImagePath,
												ContentImageId = cI.ContentImageId,
												ContentForTabId = cI.ContentForTabId
											}).SingleOrDefault();
				try
				{
					_ctx.ContentImages.Update(contentImageToEdit);
					_ctx.SaveChanges();
				}
				catch (DbUpdateException ex)
				{
					_logger.LogInformation($"Could not update file because of {ex.Message}");
				}

				return imagePath;

			}
			return null;
		}

		public bool DeleteContentImage(ContentImageDto contentImage)
		{
			bool removed = false;
			if (ContentImageExists(contentImage.ContentImageId))
			{
				removed = _imgService.DeleteImage(contentImage.OldImage, _env);

				ContentImage contentImageToEdit = _ctx.ContentImages.Where(cI => cI.ContentImageId == contentImage.ContentImageId).SingleOrDefault();
				try
				{
					_ctx.ContentImages.Remove(contentImageToEdit);
					_ctx.SaveChanges();
				}
				catch (DbUpdateException ex)
				{
					_logger.LogInformation($"Could not update file because of {ex.Message}");
				}

			}
			return removed;
		}

		public bool DeleteContentImages(ICollection<ContentImageDto> contentImage)
		{
			if (contentImage != null)
			{
				bool removed = _imgService.DeleteImages(contentImage.Select(cI => cI.OldImage).ToList(), _env);
				IEnumerable<ContentImage> imagesToRemove = _ctx.ContentImages.Where(cI => contentImage.Select(c => c.ContentImageId).Contains(cI.ContentImageId));

				if (imagesToRemove != null)
				{
					try
					{
						_ctx.ContentImages.RemoveRange(imagesToRemove);
						_ctx.SaveChanges();
						return true;
					}
					catch { }
				}
				
			}
			return false;
		}

		public bool ContentImageExists(int cId) => _ctx.ContentImages.Any(id => id.ContentImageId == cId);
	}
}