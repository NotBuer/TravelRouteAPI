using API.Endpoints;
using API.Extensions;
using Application;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddDatabase()
    .AddApplicationDependencyInjection()
    .AddJsonSerializer()
    .AddSwagger();
    
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapTravelRouteGroup();

app.Run();