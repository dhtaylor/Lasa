using Lasa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Lasa.BusinessLayer
{
    public class LoginHelper
    {
        public Login GetLogin(string loginName)
        {
            string repositoryPath = ConfigurationManager.AppSettings["Repository"].ToString();
            string fileName = loginName;

            string json = DataLayer.FileAccess.Read(repositoryPath, fileName);

            Login login = DataLayer.JsonHelper.ConvertJson<Login>(json);

            return login;
        }

        public void Save(Login login)
        {
            string repositoryPath = ConfigurationManager.AppSettings["Repository"].ToString();
            string fileName = login.Sid.ToString();

            string json = DataLayer.JsonHelper.GetJson(login);

            DataLayer.FileAccess.Write(repositoryPath, fileName, json);

        }
    }
}