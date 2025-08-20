using Microsoft.AspNetCore.Mvc.Razor;
using schedule.server.context;
using schedule.server.facade;
using schedule.server.services.crud;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ContactCrudService,ContactCrudService>();
builder.Services.AddScoped<ScheduleFacade, ScheduleFacade>();
ConfigureServices(builder.Services);

var app = builder.Build();
Configure(app, builder.Environment);
app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ScheduleContext>();
    services.AddControllersWithViews();
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
    services.Configure<RazorViewEngineOptions>(options =>
    {
        options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/schedule/api/views/{1}/{0}" + RazorViewEngine.ViewExtension);
        options.ViewLocationFormats.Add("/schedule/api/views/Shared/{0}" + RazorViewEngine.ViewExtension); 
    });
}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("api/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}