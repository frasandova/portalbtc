using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Security.Principal;

namespace WebBiotec.Models.DAO
{
    public static class IdentityExtensions
    {
        public static string GetEmailAdress(this IIdentity identity)
        {
            //ApplicationUser user2 = Microsoft.AspNet.Identity.UserManager.FindByName("","");
            //string mail = user.Email;

            var userId = identity.GetUserId();
            using (var context = new ModelMantenedores())
            {
                var user = context.AspNetUsers.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user.Email;
                }
    
            }
        }
    }
}