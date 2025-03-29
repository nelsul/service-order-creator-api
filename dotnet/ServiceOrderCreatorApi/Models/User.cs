using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ServiceOrderCreatorApi.Models
{
    public class User : IdentityUser
    {
        public string ProfilePictureFile { get; set; } = string.Empty;
    }
}
