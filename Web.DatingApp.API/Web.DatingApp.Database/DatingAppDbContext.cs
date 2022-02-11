﻿using Microsoft.EntityFrameworkCore;
using Web.DatingApp.API.Web.DatingApp.Entities;

namespace Web.DatingApp.API.Web.DatingApp.Database
{
    public class DatingAppDbContext : DbContext
    {
        public DatingAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<AppUser> tbl_User  => Set<AppUser>();
    }
}
