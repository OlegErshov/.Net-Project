using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Plugin.Authorization;
using Repository;

using Repository.Data;
using Repository.UnitOfWork;
using Application.Abstractions;
using Application.Services;
using Application.Abstractions.TaskAbstractions;
using Plugin.Tasks;
using Plugin.Questions;
using Application.Services.TaskServices;
using Application.Abstractions.QuestionAbstractions;
using Application.Services.QuestionServices;

var builder = WebApplication.CreateBuilder(args);

#region DB & Identity

var connString = builder.Configuration.GetConnectionString("SqLiteConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
                                opt.UseSqlite(connString));

builder.Services.AddDefaultIdentity<IdentityUser>(options=>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase= false;
    options.Password.RequireUppercase= false;
    options.Password.RequiredLength = 6;
    
}).AddEntityFrameworkStores<AppDbContext>();



#endregion



// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<ITaskService<GrammaTask, GrammaQuestion>, GrammaTaskService>();
builder.Services.AddScoped<IQuestionService<GrammaQuestion>, GrammaQuestionService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
