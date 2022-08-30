using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Helper
{
	public class InitialData
	{

		public static void LoadInitialData(ref ModelBuilder builder) 
		{
			builder.Entity<User>().HasData(new User
			{
				Id = 1,
				Name = "Admin",
				Surname = "Admin",
				Username = "appuser",
				Salt = "ql6oWo2",
				PasswordHash = "",
				CreateDate = DateTime.Now,
				CreateUserId = 1,
				UpdateDate = null,
				UpdateUserId = null
			});
		}
	}
}
