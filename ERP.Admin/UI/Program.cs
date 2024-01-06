using UI.Components;

using MudBlazor.Services;
using ERP.Admin.Pgsql;
using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Application.Users.Interfaces;
using Application.Users.UseCases;
using UI.ImageUploader;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<PgsqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConnection"),
    b => b.MigrationsAssembly("ERP.Admin.Pgsql")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAddUserUseCase, AddUserUseCase>();
builder.Services.AddScoped<IEditUserUseCase,EditUserUseCase>();
builder.Services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
builder.Services.AddScoped<IImageUploader, ImageUploader>();
builder.Services.AddScoped<IGetUsersByNameUseCase
    , GetUsersByNameUseCase>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
