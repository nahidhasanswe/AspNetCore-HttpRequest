using AspNetCore.HttpRequest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AspNetCore.Worker
{
    class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /// Dependency Injection Implementation Here Or Inject Servie Collection
            /// services.AddTransit<>();
            /// 
            services.AddHttpRequest()
                    .AddHttpBaseAddress("Test", "https://reqres.in");

            // This is service provider for create instance of DI object
            ServiceProvider provider = services.BuildServiceProvider();

            // This is an example of how to create instance of DI object
            var _httpRequestFactory = provider.GetService<IHttpRequestFactory>();

            _httpRequestFactory = _httpRequestFactory.BaseAddress("Test");

            var result =  _httpRequestFactory.Get("/api/users?page=2").GetAwaiter().GetResult();

            if(result.IsSuccessStatusCode)
            {
                var resultOutput = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if(!string.IsNullOrEmpty(resultOutput))
                {
                    Console.WriteLine(resultOutput);
                }
            }

            // Now you will able to execute your desired process

        }
    }
}
