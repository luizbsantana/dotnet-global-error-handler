# Dotnet Middleware: Global Error Handler
Handle errors from a .NET application with DOMAIN EXCEPTION or BUSINESS EXCEPTION triggered by you or just a unknown exception (what will be logged with a ILOGGER - Serilog) that will return a Internal Server Error status code.

<br>

## :electric_plug: Configuring the Middleware

:bulb: Configure this custom middleware correctly in you application (in Startup.cs or your custom configuration file):

```
...
public void Configure(IApplicationBuilder app)
{
    ...
    app.UseMiddleware<GlobalErrorHandler>();
    ...
}
...
```

<br>

## :floppy_disk: Configuring your ILogger

:bulb: Configure you ILogger (Serilog) to log all unknown errors:

```
...
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<ILogger>(new LoggerConfiguration().Enrich.FromLogContext().MinimumLevel.Debug().CreateLogger());
    ...
}
...
```

<br>

## :v: Contributors

[luizb_santana](https://twitter.com/luizb_santana)

## :mailbox_with_mail: License

This software was created for study purposes only. Feel free to try it out.