using FSPE.API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using FSPE.API.Utilities;

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
            ScheduleLoader.Load(@"C:\Users\keith.smith\Downloads\nfl-2015-schedule.xlsx");

        }
    }
}
