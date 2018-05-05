using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


//In order to install the package you can this command 
// PM> Install-Package Microsoft.AspNet.WebApi.Cors -Version 5.2.3
// pM> Update-Package Microsoft.AspNet.WebApi -reinstall
    //select this project in from solution Explorer then go to tools
// then NuGet Package Manger then package Manager Console
namespace aspwebapp1.Models
{
    /*
     * add new columns
     * 1.PM> add-migration ChangedDefaultColumnNames
     * 2.PM> update-database
     */
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /*
         * In Webconfig
         *"DefaultConnection" is a string in Web.config
        <connectonString>
		<add name="DefaultConnection" connectionString="Data Source=(local)\sqle2012;Initial Catalog=UserDB;Integrated Security=True" providerName="s">
			
		</add>
	</connectonString>

    operate: steps:
    1. Tools->NuGet Package Manager->Package Manager console
    2.PM>enable-migrations 
      Generation a Migrations folder.
    3. PM-> add-migration InitailDB
    4. PM-> update-database
      To create some tables such as in UserDB database, dbo._MigrationHistory
      dbo.AspNetRoles,dbo.AspNetUserClaims,
      dbo.AspNetUserLogins,dbo.AspNetUserRoles,
      dbo.AspNetUsers ,which from asp.net identity.
      AspnetUserClaims means it is expertise of a user.
         */
        public ApplicationDbContext() : 
            base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        /*
         * create tables and re-name them.
         * 1.PM> add-migration ChangedDefaultTableNames
         * 2.PM> update-database
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers to User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            //AspNetRoles to Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //AspNetUserRoles to UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            //AspNetUserClaims to UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins to UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
    }
}