using HandwritingRecognitionML.Model;
using Microsoft.Extensions.ML;
using TaxiFareML.Model;

namespace HandwritingRecognition;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddPredictionEnginePool<ModelInput, ModelOutput>()
            .FromFile(modelName: HwrModel.Name, filePath: "MLModel.zip", watchForChanges: true);
        services.AddPredictionEnginePool<TaxiFareModelInput, TaxiFareModelOutput>()
            .FromFile(modelName: TaxiFareModel.Name, filePath: "TaxiFare_MLModel.zip", watchForChanges: true);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}