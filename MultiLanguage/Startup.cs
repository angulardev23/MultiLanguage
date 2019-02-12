using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using MultiLanguage.Data;
using MultiLanguage.Services;
using System;

namespace MultiLanguage
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddOptions();
            services.Configure<DbConfig>(p =>
                Configuration.GetSection("Database").Bind(p));

            var builder = new ContainerBuilder();
            builder.RegisterType<PizzaService>().As<IPizzaService>();
            builder.RegisterType<PizzaDbContext>().As<IPizzaDbContext>();
            builder.RegisterType<LanguageHandlerService>().As<ILanguageHandlerService>();

            builder.Populate(services);

            var container = builder.Build();


            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
