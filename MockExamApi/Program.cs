var builder = WebApplication.CreateBuilder(args);

// 添加CORS策略
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

// 其他服务配置
builder.Services.AddControllers();

var app = builder.Build();

// 配置中间件
app.UseRouting();
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
