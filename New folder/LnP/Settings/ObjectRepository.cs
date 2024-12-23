﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LnP.Interfaces;
using LnP.PageObject;

namespace LnP.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static AreaBrowsePage ABpage;
        public static EventCalenderPage ECpage;
        public static HomePage Hpage;
        public static LondonTubePage LTpage;
        public static ProductPage Ppage;
        public static TagBrowsePage TBpage;
        public static ThingsToDoPage TTDpage;

    }
}
