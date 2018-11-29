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

        public static IServiceCollection AddHttpRequest(this IServiceCollection services)
        {
            services.AddSingleton<HttpRequestBuilder>();
            services.AddSingleton<IHttpRequestFactory, HttpRequestFactory>();

            return services;
        }

        public static IServiceCollection AddHttpBaseAddress(this IServiceCollection services, string BaseAddressName, string baseUri)
        {
            services.AddHttpClient(BaseAddressName, x =>
            {
                x.BaseAddress = new System.Uri(baseUri);
            });

            return services;
        }
    }
}
