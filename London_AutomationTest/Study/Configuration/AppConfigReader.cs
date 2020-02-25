using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            throw new NotImplementedException();
        }

        public int GetElementLoadTimeOut()
        {
            throw new NotImplementedException();
        }

        public int GetPageLoadTimeOut()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUsername()
        {
            throw new NotImplementedException();
        }

        public string GetWebsite()
        {
            throw new NotImplementedException();
        }
    }
}
