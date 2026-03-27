using Prometheus;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Collect HTTP request metrics
app.UseHttpMetrics();

app.MapGet("/", () => "Hello World from main branch!");

// Expose Prometheus metrics at /metrics
app.MapMetrics();

app.Run();