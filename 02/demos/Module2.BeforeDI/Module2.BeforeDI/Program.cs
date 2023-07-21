﻿using Module2.BeforeDI;
using Module2.BeforeDI.Shared;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configuration = new Configuration();
var productFormatter = new ProductFormatter();
var priceParser = new PriceParser();

var productSource = new ProductSource(configuration, priceParser);
var productTarget = new ProductTarget(configuration, productFormatter);

var productImpoter = new ProductImporter(productSource, productTarget);
productImpoter.Run();
/*
using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<Configuration>();
    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();


var configuration = new Configuration();

var priceParser = new PriceParser();
var productSource = new ProductSource(configuration, priceParser);

var productFormatter = new ProductFormatter();
var productTarget = new ProductTarget(configuration, productFormatter);
*/
