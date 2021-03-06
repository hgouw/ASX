﻿using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASX.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
        }
    }

    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null) return null; // DateTime has null value
            return value.ConvertTo(typeof(DateTime?), CultureInfo.GetCultureInfo("en-AU")); // Convert DateTime to en-AU
        }
    }
}