// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      Program.cs
// ---------------------------------------------------------------------------------------------------------------------

using RazorPagesApplication1.WebUI;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices
builder.Host.ConfigureServices((hostBuilderContext, serviceCollection) =>
{
    serviceCollection
        .AddRazorPagesApplication1(hostBuilderContext)
        .AddRazorPages();
});

var app = builder.Build();

// Configure
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();