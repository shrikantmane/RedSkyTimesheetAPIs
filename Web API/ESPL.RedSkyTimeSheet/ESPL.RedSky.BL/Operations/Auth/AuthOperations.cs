using ESPL.RedSkyTimeSheet.BL.Models;
using ESPL.RedSkyTimeSheet.BL.Operations.Common;
using ESPL.RedSkyTimeSheet.Lists;
using ESPL.SHAREPOINT.RESTSERVICE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace ESPL.RedSkyTimeSheet.BL.Operations.Auth
{
    public class AuthOperations
    {
       
        public User CurrentUserName()
        {
            try
            {
                return new User
                {
                    ID = GetUserInfo.UserID,
                    Name = GetUserInfo.UserName
                };
            }
            catch (Exception ex)
            {
                string guid = RestAPI.WriteException(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
                throw new Exception(string.Format(Lists.Messages.MsgExceptionOccured, guid));
            }
        }

        public string[] UserRoles()
        {
            string roles = GetUserInfo.UserRole;
            if (string.IsNullOrEmpty(roles))
                return new string[] { };
            else
                return roles.Split(',');

        }
    }
}
