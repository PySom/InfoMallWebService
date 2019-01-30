using InfoMallWebService.Dtos;
using InfoMallWebService.Models;
using System.Collections.Generic;

namespace InfoMallWebService.Repository
{
	public interface IContentImageRepository
	{
		void AddContentImages(int contentForTabId, List<ContentImageDto> contentImage);
		string EditContentImage(ContentImageDto contentImage);
		bool DeleteContentImage(ContentImageDto contentImage);
		bool DeleteContentImages(ICollection<ContentImageDto> contentImages);
		bool AddContentImage(ContentImageDto contentImage);
	}
}