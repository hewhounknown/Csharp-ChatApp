using ChatApp.Infrastructure.Cache;
using ChatApp.Infrastructure.Db;
using ChatApp.Web;
using ChatApp.Web.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//mongo
string connectionString = builder.Configuration.GetSection("MongoDBSettings:ConnectionString").Value!;
string databaseName = builder.Configuration.GetSection("MongoDBSettings:DatabaseName").Value!;

//logger
string logFile = builder.Configuration.GetSection("Logging:LogFile").Value!;
string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFile);

//redis
string host = builder.Configuration.GetSection("RedisSettings:HostName").Value!;
string port = builder.Configuration.GetSection("RedisSettings:PortNumber").Value!;
string password = builder.Configuration.GetSection("RedisSettings:Password").Value!;

//set up logger
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

  //Add mongodb
  builder.Services.AddScoped(opt =>
      new MongoDbConnection(connectionString, databaseName)
  );

  //Add redis
  builder.Services.AddScoped(opt =>
      new Redis(host, port, password)
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
