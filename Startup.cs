using Microsoft.OpenApi.Models;
using UplaceApi.Repository;

namespace UplaceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "uplace-api", Version = "v1" });
            });

            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var database = Environment.GetEnvironmentVariable("DB_DATABASE");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var pooling = Environment.GetEnvironmentVariable("DB_POOLING");

            if (string.IsNullOrEmpty(server))
            {
                throw new Exception("Variável de ambiente DB_SERVER não definida");
            }

            if (string.IsNullOrEmpty(port))
            {
                throw new Exception("Variável de ambiente DB_PORT não definida");
            }

            if (string.IsNullOrEmpty(database))
            {
                throw new Exception("Variável de ambiente DB_DATABASE não definida");
            }

            if (string.IsNullOrEmpty(user))
            {
                throw new Exception("Variável de ambiente DB_USER não definida");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Variável de ambiente DB_PASSWORD não definida");
            }

            if (string.IsNullOrEmpty(pooling))
            {
                throw new Exception("Variável de ambiente DB_POOLING não definida");
            }

            string connectionString =
                $"Server={server}, {port}; Database={database}; User Id={user}; Password={password}; Pooling={pooling}";

            services.AddScoped<ITesteRepository>(factory => {
                return new TesteRepository(connectionString);
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "uplace-api v1"));
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
}
