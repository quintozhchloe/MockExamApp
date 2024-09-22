var builder = WebApplication.CreateBuilder(args);

// ���CORS����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// ������������
builder.Services.AddControllers();

var app = builder.Build();

// �����м��
app.UseRouting();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
