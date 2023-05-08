using FluentValidation.AspNetCore;
using SafeBankIdentity.BusinessLayer.ValidationRules.AppUserValidationRules;
using SafeBankIdentity.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessRegistration(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AppUserRegisterDTOValidator>());

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
