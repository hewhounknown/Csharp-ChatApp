using ChatApp.Infrastructure.Db;
using ChatApp.Web;
using ChatApp.Web.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string logFile = builder.Configuration.GetSection("Logging:LogFile").Value!;
string connectionString = builder.Configuration.GetSection("MongoDBSettings:ConnectionString").Value!;
string databaseName = builder.Configuration.GetSection("MongoDBSettings:DatabaseName").Value!;

string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFile);

Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .WriteTo.File(logFilePath)
              .CreateLogger();

try
{
  Log.Information("Starting Chat App...");

  // Add services to the container.
  builder.Services.AddControllersWithViews();
  builder.Services.AddSignalR();

  //Dependency Injections 
  builder.Services.AddScoped(opt =>
      new MongoDbConnection(connectionString, databaseName)
  );

  builder.Services.AddServices();

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  if (!app.Environment.IsDevelopment())
  {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
  }

  app.UseHttpsRedirection();
  app.UseStaticFiles();

  app.UseRouting();

  app.UseAuthorization();

  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Auth}/{action=Login}/{id?}");

  app.MapHub<ChatHub>("/chatHub");

  app.Run();

}
catch (Exception ex)
{

  Log.Fatal(ex, "Chat App terminated unexpectedly!");
}
finally
{
  Log.CloseAndFlush();
}
