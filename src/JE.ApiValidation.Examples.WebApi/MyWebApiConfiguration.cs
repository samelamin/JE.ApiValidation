﻿using System.Web.Http;
using FluentValidation.WebApi;
using JE.ApiValidation.WebApi;
using JE.ApiValidation.WebApi.FluentValidation;

namespace JE.ApiValidation.Examples.WebApi
{
    public class MyWebApiConfiguration : HttpConfiguration
    {
        public MyWebApiConfiguration()
        {
            ConfigureRouting();
            ConfigureRequestValidation();
            ConfigureResponseProcessingErrorHandling();
        }

        private void ConfigureResponseProcessingErrorHandling()
        {
            Filters.Add(new ResponseProcessingErrorAttribute());
        }

        private void ConfigureRequestValidation()
        {
            FluentValidationModelValidatorProvider.Configure(this, provider => provider.ValidatorFactory = new ForExampleSitesValidatorFactoryButDontUseThisUseAContainer());
            Filters.Add(new FilterForInvalidRequestsAttribute());
        }

        private void ConfigureRouting()
        {
            Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}
