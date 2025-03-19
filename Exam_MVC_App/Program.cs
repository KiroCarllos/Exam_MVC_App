using Exam_MVC_App.Data;
using Exam_MVC_App.Mappings;
using Exam_MVC_App.Services.BranchServices;
using Exam_MVC_App.Services.CourseServices;
using Exam_MVC_App.Services.InstructorDetailsServices;
using Exam_MVC_App.Services.InstructorServices;
using Exam_MVC_App.Services.QuestionChoiseServies;
using Exam_MVC_App.Services.QuestionRightAnswerServices;
using Exam_MVC_App.Services.QuestionsServices;
using Exam_MVC_App.Services.TrackServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAppDBContextProcedures, AppDBContextProcedures>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IInstructorDetailsService, InstructorDetailsService>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<IQuestionsServise, QuestionsService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IQusestionChoiseServece, QusestionChoiseServie>();
builder.Services.AddScoped<IQuestionRightAnswerservice, QuestionRightAnswerService>();
builder.Services.AddScoped<ITrackServices, TrackServices>();



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
