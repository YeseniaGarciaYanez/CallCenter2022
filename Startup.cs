using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json;


    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string json = File.ReadAllText("Config\\config.json");
            Config.Configuration = JsonConvert.DeserializeObject<Config>(json);
        }

        // Aquí se registran los servicios (inyección de dependencias, controladores, etc.)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Puedes agregar más servicios aquí, como Swagger, CORS, etc.
            // services.AddSwaggerGen();
        }

        // Aquí se configura el middleware del pipeline HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
