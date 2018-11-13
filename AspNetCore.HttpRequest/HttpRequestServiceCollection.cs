using AspNetCore.HttpRequest;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHttpRequest(this IServiceCollection services, string baseUri)
        {
            services.AddHttpClient("AspNetCore.HttpRequest", x =>
            {
                x.BaseAddress = new System.Uri(baseUri);
            });

            services.AddSingleton<HttpRequestBuilder>();
            services.AddSingleton<IHttpRequestFactory, HttpRequestFactory>();

            return services;
        }

        //public static iservicecollection addhttprequest(this iservicecollection services, string uriname, string baseuri)
        //{
        //    services.addhttpclient(uriname, x =>
        //    {
        //        x.baseaddress = new system.uri(baseuri);
        //    });

        //    services.addsingleton<httprequestbuilder>();
        //    services.addsingleton<ihttprequestfactory, httprequestfactory>();

        //    return services;
        //}
    }
}
