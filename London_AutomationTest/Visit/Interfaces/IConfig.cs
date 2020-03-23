using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visit.Configuration;

namespace Visit.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        string GetConventionWebsite();
        string GetBusinessWebsite();
        string GetStudyWebsite();
        string GetPreviewWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
