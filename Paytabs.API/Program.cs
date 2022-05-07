// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using Paytabs.DependencyInjection;
using Paytabs.SDK.Interfaces;
using Paytabs.SDK.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPaytabs(config => {
    config.ServerKey = builder.Configuration.GetValue<string>("PaytabsServerKey");
    config.ProfileId = builder.Configuration.GetValue<long>("PaytabsProfileId");
    config.HideShipping = true;
    config.EnableIFrame = true;
});

//builder.Services.AddSingleton<HttpService>().AddHttpClient<HttpService>();
/*builder.Services.AddSingleton(p => new PaytabsConfig
{
    ServerKey = builder.Configuration.GetValue<string>("PaytabsServerKey"),
    ProfileId = builder.Configuration.GetValue<long>("PaytabsProfileId"),
    HideShipping = true,
    EnableIFrame = true
});*/

//builder.Services.AddScoped<IPaytabsTransaction, PaytabsTransaction>();

var app = builder.Build();
app.MapGet("/", async (IPaytabsTransaction _paytabsTransaction,CancellationToken cancellationToken) =>
{
    PaymentRequest paymentRequest = new ()
    {
        TransactionType = TransactionType.SALE,
        TransactionClass= TransactionClass.ECOM,
        CartId = "897961dd-d91e-45a9-ac9e-d1b34d49bad9",
        CartDescription = "Dummy Order 4696563498614784",
        CartCurrency = "EGP",
        CartAmount = 55.40,
        CustomerDetails = new () 
        {
            Fullname = "Ramez Ahmed",
            Email = "Ramez@gmail.com",
            Address = " 20 Nasr City",
            City = "Cairo",
            Country = "EGY",
            IP = "94.204.129.89"
        },
        /*CardDetails = new() 
        {
             CardNumbers = "4000000000000002",
             CVV ="123",
             ExpiryMonth=12,
             ExpiryYear=25

        }*/
    };

    return await _paytabsTransaction.CreatePayment(paymentRequest, cancellationToken);
});

app.MapGet("/query/reference", async (IPaytabsTransaction _paytabsTransaction, CancellationToken cancellationToken) =>
{
    QueryReferenceRequest request = new() { TransactionReference = "TST2212001212417" };

    return await _paytabsTransaction.MakeInquire(request,cancellationToken);
});


app.MapGet("/query/token", async (IPaytabsTransaction _paytabsTransaction, CancellationToken cancellationToken) =>
{
    QueryTokenRequest request = new() { Token = "2C4651BF67A3EC34C6B691F8638B75BC" };

    return await _paytabsTransaction.MakeInquire(request, cancellationToken);
});


app.MapDelete("/query/token", async (IPaytabsTransaction _paytabsTransaction, CancellationToken cancellationToken) =>
{
    DeleteTokenRequest request = new() { Token = "2C4651BF67A3EC34C6B691F8638B75BC" };

    return await _paytabsTransaction.DeleteToken(request, cancellationToken);
});


app.Run();
