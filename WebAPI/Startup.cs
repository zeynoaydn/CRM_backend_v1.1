using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using Core.Utilities.Security.JWT;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Extensions;
using TokenOptions =Core.Utilities.Security.JWT.TokenOptions;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //apimize bizim dýþýmýzdan bir veri gelirse onun için izin veriyoruz
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                //bilmem ne localhosttan gelen verileri kabul ettiðimizi yazdýk
                builder => builder.WithOrigins("http://localhost:3000"));
            });

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //bilmem ne localhost tan gelen verilere cevap ver demek
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //eve girmek için anahtar

            app.UseAuthorization(); //o evin içinde neler yapabilir örneðin annem benim odama girrmez

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
