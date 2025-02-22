﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using Hopsital.Bootstrapping;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hopsital
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			//Web API configuration and services
			//Configure Web API to use only bearer token authentication.

			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			//config.Services.Replace(typeof(IHttpControllerActivator), new ControllerActivator());

			//config.Formatters.Remove(config.Formatters.XmlFormatter);
			//config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
			//{
			//	ContractResolver = new CamelCasePropertyNamesContractResolver()
			//};
		}
    }
}
