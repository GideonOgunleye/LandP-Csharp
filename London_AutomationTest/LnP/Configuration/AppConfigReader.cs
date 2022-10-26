using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.Interfaces;
using LnP.Settings;

namespace LnP.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }

        public string GetConventionWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.ConventionWebsite);
        }

        public string GetBusinessWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.BusinessWebsite);
        }

        public string GetLnPWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.LondonAndPartnersWebsite);
        }

        public string GetPreviewWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.PreviewWebsite);
        }

        public string GetConventionPreviewWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.ConventionPreviewWebsite);
        }

        public string GetBusinessPreviewWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.BusinessPreviewWebsite);
        }

        public string GetStudyPreviewWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.StudyPreviewWebsite);
        }
    }
}
