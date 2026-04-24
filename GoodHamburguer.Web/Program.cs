using GoodHamburguer.Web;
using GoodHamburguer.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ── HttpClient apontando para a API ──────────────────────────────────────────
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// ── Injeção de dependência ───────────────────────────────────────────────────
builder.Services.AddScoped<ICardapioService, CardapioService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

await builder.Build().RunAsync();
