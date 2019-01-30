﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Services
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
		Task SendEmailToAllAsync(List<string> emails, string subject, string message);
	}
}
