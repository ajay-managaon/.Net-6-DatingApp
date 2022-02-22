﻿using Web.DatingApp.API.Web.DatingApp.Entities;
using Web.DatingApp.API.Web.DatingApp.Extensions;

namespace Web.DatingApp.API.Web.DatingApp.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; } 
        public string Introduction { get; set; } 
        public string LookingFor { get; set; } 
        public string Interests { get; set; }
        public string City { get; set; } 
        public string Country { get; set; } 
        public ICollection<PhotoDto> Photos { get; set; } 
    }
}