using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InfoMallWebService.Services
{
    public class ImageService : IImageService
	{
		public static Random random = new Random(55);
		public ImageService(){}
		public string CreateImage(IFormFile file, IHostingEnvironment _env)
		{
			string fileDefault = AppConstant.ImagePath;
			string relativePath = "";
			if (file != null)
			{
				
					int randomId = ImageService.random.Next(56, 1000);
					var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
					relativePath = Path.Combine(fileDefault, fileName);
					var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

					using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
	
				return relativePath;
			}
			return null;
		}
		public List<string> CreateImages(IEnumerable<IFormFile> files, IHostingEnvironment _env)
		{
			string fileDefault = AppConstant.ImagePath;
			List<string> relativePaths = new List<string>();
			string relativePath = "";
			if (files != null)
			{
				foreach(var file in files)
				{
					int randomId = ImageService.random.Next(56, 1000);
					var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
					relativePath = Path.Combine(fileDefault, fileName);
					var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

					using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					relativePaths.Add(relativePath);
					relativePath = "";

				}
				return relativePaths;
			}
			return null;
		}

		public string EditImage(IFormFile file, string imageUrl, IHostingEnvironment env)
		{
			string fileDefault = AppConstant.ImagePath;
			if (file!=null)
			{
				string relativePath = "";
				if (!string.IsNullOrEmpty(imageUrl))
				{
					var oldPath = Path.Combine(env.WebRootPath, imageUrl);
					if (System.IO.File.Exists(oldPath))
					{
						System.IO.File.Delete(oldPath);
					}
				}
				int randomId = ImageService.random.Next(56, 1000);
				var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
				relativePath = Path.Combine(fileDefault, fileName);
				var absolutePath = Path.Combine(env.WebRootPath, relativePath);

				using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				return relativePath;

			}
			return null;
		}

		public List<string> EditImages(List<IFormFile> files, List<string> imageUrls, IHostingEnvironment _env)
		{
			string fileDefault = AppConstant.ImagePath;
			if (files != null)
			{
				List<string> relativePaths = new List<string>();
				string relativePath = "";
				if (imageUrls != null)
				{
					foreach(string imageUrl in imageUrls)
					{
						var oldPath = Path.Combine(_env.WebRootPath, imageUrl);
						if (System.IO.File.Exists(oldPath))
						{
							System.IO.File.Delete(oldPath);
						}
					}
					
				}
				foreach(IFormFile file in files)
				{
					int randomId = ImageService.random.Next(56, 1000);
					var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
					relativePath = Path.Combine(fileDefault, fileName);
					var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

					using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					relativePaths.Add(relativePath);
					relativePath = "";

				}
				return relativePaths;
			}
			return null;
		}

		//Delete a single image
		public bool DeleteImage(string ImageUrl, IHostingEnvironment _env)
		{
			if (string.IsNullOrEmpty(ImageUrl))
			{
				ImageUrl = "";
			}
			var oldPath = Path.Combine(_env.WebRootPath, ImageUrl);
			if (System.IO.File.Exists(oldPath))
			{
				System.IO.File.Delete(oldPath);
				return true;
			}
			return false;
		}

		//Delete multiple images
		public bool DeleteImages(List<string> images, IHostingEnvironment _env)
		{
			if(images != null)
			{
				foreach(string image in images)
				{
					var oldPath = Path.Combine(_env.WebRootPath, image);
					if (System.IO.File.Exists(oldPath))
						{
							System.IO.File.Delete(oldPath);
						}
				}
				return true;
			}
			return false;
		}

        
    }
}