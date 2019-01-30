using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InfoMallWebService.Services
{
    public interface IImageService
    {
        
    	string CreateImage(IFormFile file, IHostingEnvironment _env);
		List<string> CreateImages(IEnumerable<IFormFile> files, IHostingEnvironment _env);

		string EditImage(IFormFile file, string imageUrl, IHostingEnvironment env);

		List<string> EditImages(List<IFormFile> files, List<string> imageUrls, IHostingEnvironment _env);
		bool DeleteImage(string ImageUrl, IHostingEnvironment _env);
		bool DeleteImages(List<string> images, IHostingEnvironment _env);
		
	}
}