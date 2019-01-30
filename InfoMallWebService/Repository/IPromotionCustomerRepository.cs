using InfoMallWebService.Dtos;
using InfoMallWebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Repository
{
	public interface IPromotionCustomerRepository
	{
		Task<(bool, bool)> AddCustomerProduct(PromotionCustomerDto promotionCustomerDto);
		Task<PromotionCustomer> GetCustomerProductById(int id);
		Task<List<PromotionCustomer>> GetAllCustomerProduct();
		Task DeletePromotionCustomerWithId(int id);
        Task<List<PromotionCustomer>> GetAllCustomerProductsByUserId();
        Task UpdatePromotionCustomerWithId(PromotionCustomerDto promotionCustomer);

    }
}
