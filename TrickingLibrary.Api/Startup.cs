using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrickingLibrary.Data;


namespace TrickingLibrary.Api
{
    public class Startup
    {
        const int MaxRequestLimit = 737280000;
        private const string CorsPolicyAll = "All";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(opt =>
                opt.AddPolicy(CorsPolicyAll, builder =>
                    builder
                        .AllowAnyHeader()
                        .AllowAnyHeader()
                        .AllowAnyOrigin())
            );
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = MaxRequestLimit;
            });
            services.AddDbContext<Data.AppDbContext>(option=>option.UseInMemoryDatabase("dev"));
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = MaxRequestLimit;
                x.MultipartBodyLengthLimit = MaxRequestLimit;
                x.MultipartHeadersCountLimit = MaxRequestLimit;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(CorsPolicyAll);
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}