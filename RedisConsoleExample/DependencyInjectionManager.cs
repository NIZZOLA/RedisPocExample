using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisDataRepository.Interface;
using RedisDataRepository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RedisConsoleExample
{
    public class DependencyInjectionManager : IDependencyInjectionManager
    {
        private IServiceCollection services;
        private IConfigurationRoot Configuration { get; }

        public ServiceProvider ServiceProvider { get; private set; }

        public DependencyInjectionManager()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            services = new ServiceCollection();
            AddDependencies();
        }


        protected virtual void AddDependencies()
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IRedisRepository, RedisRepository>();
            
            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
