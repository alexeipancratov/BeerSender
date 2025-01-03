﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder();

builder.ConfigureHostConfiguration(config =>
{
    config.AddJsonFile("appsettings.json", false);
    config.AddEnvironmentVariables();
});

builder.ConfigureServices((_, services) =>
{
    // services.RegisterDataConnections();
});

var app = builder.Build();

app.Run();