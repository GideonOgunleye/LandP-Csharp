using Convention.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convention.Interface
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        string GetPreviewWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
