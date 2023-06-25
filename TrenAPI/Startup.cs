using Microsoft.OpenApi.Models;

namespace TrenAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
     
        services.AddControllers();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

      
            app.UseSwagger();
            app.UseSwaggerUI(setup => {

                string basePath = string.IsNullOrWhiteSpace(setup.RoutePrefix) ? "." : "..";
                setup.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "Versiyon 1.0");
                setup.OAuthAppName("Tren Lambda Api");
                setup.OAuthScopeSeparator(" ");
                setup.OAuthUsePkce();
                    });
        

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}