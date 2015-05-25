using FSPE.API.DAL;
using FSPE.API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using FSPE.API.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FSPE.API.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<DAL.PoolManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.PoolManagerContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PoolManagerContext()));
            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "keith@kssoftware.net",
                EmailConfirmed = true,
                FirstName = "Keith",
                LastName = "Smith",
                Status = UserStatus.Standard,
                JoinDate = DateTime.UtcNow
            };

            manager.Create(user, "V0lleyB@ll");

            ScheduleLoader.Load(@"C:\Users\keith.smith\Downloads\nfl-2015-schedule.xlsx");

        }
    }
}
