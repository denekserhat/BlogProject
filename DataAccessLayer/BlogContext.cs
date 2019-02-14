﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class BlogContext : DbContext
    {
        //dbcontext options is derived from basecontext
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        //generetes dbsets which are instances of tables of db
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
