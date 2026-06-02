using ZohoDeskIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ZohoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// ✅ Middleware order is VERY IMPORTANT

app.UseHttpsRedirection();

// ✅ Enable CORS (if needed)
app.UseCors("AllowAll");

// ✅ Serve HTML FIRST (this fixes your issue)
var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");   // 🔥 change to your main page

app.UseDefaultFiles(options);
app.UseStaticFiles();

// ✅ Swagger AFTER static files
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger"; // 🔥 so it opens only at /swagger
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();