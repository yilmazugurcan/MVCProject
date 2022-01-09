using DataAccess.Context;
using SERVICE.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WEBUI.Models
{
    public class AppUserRoleProvider : RoleProvider
    {
        AppDbContext db = ProjectSingleton.Context;

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var userRoleList = from user in db.AppUsers join userandrole in db.AppUserAndRoles on user.AppUserId equals userandrole.AppUserId join role in db.Roles on userandrole.RoleId equals role.RoleId where user.Username == username select role.RoleName;

            //Todo: yukarıdaki işlem linq to entity ile nasıl nasıl yazılır?

            return userRoleList.ToArray();

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        //linq to sql




    }
}