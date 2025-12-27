using NotificationService.Background;
using NotificationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EmailSender>();
builder.Services.AddSingleton<SmsSender>();
builder.Services.AddSingleton<PushSender>();
builder.Services.AddSingleton<NotificationDispatcher>();

builder.Services.AddHostedService<NotificationBackgroundWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
