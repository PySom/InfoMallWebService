using InfoMallWebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Repository
{
	public interface IContactInfoRepository
	{
		Task<(bool, string)> AddContact(ContactInformation contact);
		Task<ContactInformation> GetContactInfo(int id);
		Task<List<ContactInformation>> GetAllContactsInfo();
		Task UpdateContactInfoById(ContactInformation contact);
		void DeleteContactInfoById(int id);
	}
}
