using InfoMallWebService.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Repository
{
	public interface IBannerRepository
	{
		Task<BannerInformationDto> GetBannerByCategoryId(int id);
		Task<BannerInformationDto> GetBannerByBannerId(int id);
		Task<List<BannerInformationDto>> GetAllBanners();
		Task AddBanner(BannerInformationDto banner);
		Task UpdateBannerWithId(BannerInformationDto banner);
		void DeleteBanner(int id);
	}
}
