using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GovPredict
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

      services.AddCors(options =>
      {
        options.AddPolicy("AllowMyOrigin", builder =>
          builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
      });
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();

      //Serve index.html as root 
      DefaultFilesOptions options = new DefaultFilesOptions();
      options.DefaultFileNames.Clear();
      options.DefaultFileNames.Add("index.html");
      app.UseDefaultFiles(options);

      app.UseCors("AllowMyOrigin");

      app.UseStaticFiles();

      app.UseRouting();

      // app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
