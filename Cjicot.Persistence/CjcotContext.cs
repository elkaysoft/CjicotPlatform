﻿using Cjicot.Persistence.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence
{
    public class CjcotContext: DbContext
    {
        public CjcotContext()
        {
        }

        public CjcotContext(DbContextOptions<CjcotContext> options)
            :base(options)  
        {
        }

        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

    }
}