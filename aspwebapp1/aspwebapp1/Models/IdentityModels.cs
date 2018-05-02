using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace aspwebapp1.Models
{
    public class ApplicationUser : IdentityUser
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /*
         *"DefaultConnection" is a string in Web.config
        <connectonString>
		<add name="DefaultConnection" connectionString="Data Source=(local)\sqle2012;Initial Catalog=UserDB;Integrated Security=True" providerName="s">
			
		</add>
	</connectonString>
         */
        public ApplicationDbContext() : 
            base("DefaultConnection", throwIfV1Schema: false) {
        }
    }
}