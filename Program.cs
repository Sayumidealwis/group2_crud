using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddDbContext<simplecrud.Database.DBContext> (
    option => option.UseMySQL("server=localhost;port=3307;database=prototype;user=root;password=19240")
);*/
builder.Services.AddDbContext<simplecrud.Database.DBContext>(
    option => option.UseMySQL(builder.Configuration.GetConnectionString("DefaultConString"))
);

builder.Services.AddCors(option => option.AddPolicy("CorsPolicy", policy => {
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
