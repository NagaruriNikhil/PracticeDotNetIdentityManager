﻿using Microsoft.AspNetCore.Identity;

namespace IdentityManager.Models
{
	public class ApplicationUser :IdentityUser
	{
        public string Name { get; set; }
    }
}
