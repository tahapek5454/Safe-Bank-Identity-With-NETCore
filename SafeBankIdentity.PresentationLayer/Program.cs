using FluentValidation.AspNetCore;
using SafeBankIdentity.BusinessLayer;
using SafeBankIdentity.BusinessLayer.ValidationRules.AppUserValidationRules;
using SafeBankIdentity.DataAccessLayer;
using SafeBankIdentity.PresentationLayer.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessRegistration(builder.Configuration);
builder.Services.AddBusinessRegistration();

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidationFilter>();
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AppUserRegisterDTOValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
