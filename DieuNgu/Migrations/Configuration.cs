using DieuNgu.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DieuNgu.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                  new UserStore<ApplicationUser>(
                      new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = @"username",
                FirstName = @"first",
                LastName = @"last",
                Email = @"firstlast@gmail.com",
            };
            manager.Create(user, @"");

        }
    }
}
