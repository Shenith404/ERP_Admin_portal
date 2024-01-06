﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Admin.Pgsql
{
    public class PgsqlDbContext : DbContext
    {
        public PgsqlDbContext(DbContextOptions<PgsqlDbContext> options) : base(options) { }

      


        // Tables
        public DbSet<User> Users { get; set; }
    }
}
