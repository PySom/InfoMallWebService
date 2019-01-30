using InfoMallWebService.Data;
using InfoMallWebService.Dtos;
using InfoMallWebService.Models;
using InfoMallWebService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoMallWebService.Repository
{
	public class ContactInfoRepository : IContactInfoRepository
	{
		private readonly ApplicationDbContext _ctx;
		private readonly ILogger<ContactInfoRepository> _logger;
		private readonly IEmailSender _email;
		private readonly UserManager<ApplicationUser> _userManager;

		public ContactInfoRepository(ApplicationDbContext context, 
			ILogger<ContactInfoRepository> logger, 
			IEmailSender email,
			UserManager<ApplicationUser> userManager)
		{
			_ctx = context;
			_logger = logger;
			_email = email;
			_userManager = userManager;
		}
		public async Task<(bool, string)> AddContact(ContactInformation contact)
		{
			try
			{
				_ctx.ContactsInformation.Add(contact);
				await _ctx.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogInformation($"Contact Information record not created: {ex.Message}");
				return (false, "failed");
			}
			if (contact.ContactType)
			{
				try
				{
					var user = await _userManager.Users.Where(u => u.Id == contact.UserId).SingleOrDefaultAsync();
					string userEmail = user.Email;
					await _email.SendEmailAsync(userEmail, "WE RECEIVED YOUR COMPLIANT", contact.Message);
				}
				catch (Exception ex)
				{
					_logger.LogInformation($"Contact Information record not created: {ex.Message}");
					return (true, "not sent");

				}
			}
			return (true, "sent");
		}

		public async Task<ContactInformation> GetContactInfo(int id)
		{
			if (ContactInfoExists(id))
			{
				return await _ctx.ContactsInformation.SingleOrDefaultAsync(c => c.ContactId == id);

			}
			return null;
		}

		public async Task<List<ContactInformation>> GetAllContactsInfo() => await _ctx.ContactsInformation.ToListAsync();

		public async Task UpdateContactInfoById(ContactInformation contact)
		{
			if (ContactInfoExists(contact.ContactId))
			{
				try
				{
					_ctx.ContactsInformation.Update(contact);
					await _ctx.SaveChangesAsync();
                    return;
				}
				catch (Exception ex)
				{
					_logger.LogInformation($"Contact record not updated: {ex.Message}");
				}

			}
			throw new Exception();
		}

		public void DeleteContactInfoById(int id)
		{
			if (ContactInfoExists(id))
			{
				ContactInformation contact = _ctx.ContactsInformation.Find(id);
				try
				{
					_ctx.ContactsInformation.Remove(contact);
					_ctx.SaveChanges();
                    return;
				}
				catch (Exception ex)
				{
					_logger.LogInformation($"Contact record not deleted: {ex.Message}");
				}

			}
			throw new Exception();
		}

		public async Task<bool> SendUserEmail(SendUserEmailDto emailDto)
		{
			string userEmail = null;
			var user = await _userManager.Users.Where(u => u.Id == emailDto.UserId).SingleOrDefaultAsync();
			if (user != null)
			{
				userEmail = user.Email;
			}
			if (userEmail != null)
			{
				try
				{
					await _email.SendEmailAsync(userEmail, emailDto.Subject, emailDto.Message);
					return true;
				}
				catch (Exception ex)
				{
					_logger.LogInformation($"Email not sent: {ex.Message}");
					return false;
				}
			}
			return false;
		}

		public bool ContactInfoExists(int id) => _ctx.ContactsInformation.Any(c => c.ContactId == id);
	}
}
