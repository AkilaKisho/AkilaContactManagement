using Microsoft.EntityFrameworkCore;

using AngularProject.Models; // Your DbContext Namespace 



var builder = WebApplication.CreateBuilder(args);



// Database Connection 

var connectionString = builder.Configuration.GetConnectionString("DevConnection");

var serverVersion = ServerVersion.AutoDetect(connectionString);



builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseMySql(connectionString, serverVersion));  // ✅ Fix Here 



// Add services 

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



// CORS Policy 

builder.Services.AddCors();

builder.Services.AddCors(options =>

{

    options.AddPolicy("allowCors", builder =>

    {

        builder.WithOrigins("https://localhost:4200", "http://localhost:4200")

               .AllowCredentials()

               .AllowAnyMethod()

               .AllowAnyHeader();

    });

});



var app = builder.Build();



if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}



app.UseCors("allowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();