using Assignment_6_WebApi.Models;
using Assignment_6_WebApi.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
     public class TestUserStoryContext : IUserStoryContext
    {
        public TestUserStoryContext()
        {
            this.UserStories = new TestUserDbSet();
        }

        public DbSet<UserStory> UserStories { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        //public void MarkAsModified(Product item) { }
        public void Dispose() { }
    }
}
