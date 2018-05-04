using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using aspMVCstorage.Models;

namespace aspMVCstorage.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outResult = false;
            using (authtrainEntities1 db = new authtrainEntities1())
            {
                user user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                    {
                        outResult = true;
                    }
                }
            }

            return outResult;
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[]{};
            using (authtrainEntities1 db = new authtrainEntities1())
            {
                user user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user!= null)
                {
                    role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null)
                    {
                        roles = new[] {userRole.Name};
                    }
                }
            }

            return roles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}