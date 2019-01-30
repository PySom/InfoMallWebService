using InfoMallWebService.Dtos;
using InfoMallWebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Repository
{
	public interface ICustomerProductRepository
	{
		Task<(bool, bool)> AddCustomerProduct(CustumerProductDto customerProductDto);
		Task<CustomerProduct> GetCustomerProductById(int id);
		Task<List<CustomerProduct>> GetAllCustomerProducts();
		Task UpdateCustomerProductWithId(CustomerProduct customerProduct);
		void DeleteCustomerProductWithId(int id);
	}
}
