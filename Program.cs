// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.DependencyInjection;





// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllers();
// var app = builder.Build();

// app.UseRouting();
// app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

// app.Run();



// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.DependencyInjection;

// var builder = WebApplication.CreateBuilder(args);

// // Register MVC controllers
// builder.Services.AddControllers();

// var app = builder.Build();

// // Use routing and map controllers
// app.UseRouting();

// app.UseEndpoints(endpoints => {
//     endpoints.MapControllers();  // Map API controllers
// });

// app.Run();  // Start the app


// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);

// // Register MVC controllers
// builder.Services.AddControllers();

// var app = builder.Build();

// // Use routing and map controllers
// app.MapControllers();  // Map API controllers directly

// // Run the application
// app.Run();


// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);

// // Register MVC controllers
// builder.Services.AddControllers();

// // Add CORS policy
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin() // Allow requests from any origin (e.g., frontend on port 5173)
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//     });
// });

// var app = builder.Build();

// // Use CORS before routing
// app.UseCors("AllowAll");

// // Map API controllers
// app.MapControllers();

// app.Run();


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register MVC controllers
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS before routing
app.UseCors("AllowAll");

// Serve frontend static files
app.UseDefaultFiles(); // look for index.html
app.UseStaticFiles();

// Map API controllers
app.MapControllers();

// For any other route, serve index.html (SPA fallback)
app.MapFallbackToFile("index.html");

app.Run();
