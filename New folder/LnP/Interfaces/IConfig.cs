﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.Configuration;

namespace LnP.Interfaces
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
        string GetConventionPreviewWebsite();
        string GetStudyPreviewWebsite();
        string GetBusinessPreviewWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
