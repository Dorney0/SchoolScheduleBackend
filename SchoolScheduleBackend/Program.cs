using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключаем DbContext к PostgreSQL (в Docker)
builder.Services.AddDbContext<SchoolScheduleContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры Web API
builder.Services.AddControllers();

// Добавляем Swagger для документации API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // В режиме разработки включаем Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Для продакшена можно настроить обработку ошибок и https
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();