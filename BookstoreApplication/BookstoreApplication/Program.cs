using BookstoreApplication.Models;
using BookstoreApplication.Repositorys;
using BookstoreApplication.Services;
using BookstoreApplication.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<MappingProfile>();
});

// Add services to the container.
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IAwardRepository, AwardRepository>();
builder.Services.AddScoped<IAwardService, AwardService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookServise, BookServise>();

builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<PublisherRepository>();
builder.Services.AddScoped<AwardRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
