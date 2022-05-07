# Paytabs-SDK
Paytabs SDK and Dependency injection for .NET SDK to help you integrate with the Paytabs payment gateway.

**if you like this work, please consider give the project star 🌟**

## Features

- Supporting .NET Standard 2.0+ .NET Core 2.0+.
- Manage authentication tokens - The library manage authenticate (using the configured ServerKey)

## Installation

Using the [.NET CLI tools][dotnet-core-cli-tools]:

```sh
dotnet add package Paytabs.SDK --version 1.0.0
```

Using the [NuGet CLI][nuget-cli]:

```sh
nuget Install-Package Paytabs.SDK -Version 1.0.0
```



Using the [.NET CLI tools][dotnet-core-cli-tools]:

```sh
dotnet add package Paytabs.DependencyInjection --version 1.0.0
```

Using the [NuGet CLI][nuget-cli]:

```sh
nuget Install-Package Paytabs.DependencyInjection -Version 1.0.0
```



## Usage

### Configuration Dependency Injection

Configure the library in `Startup.cs` or `Program.cs` in case .net 6 with these helper methods.


```c#
 
services.AddPaytabs(config => {
    config.ServerKey = "Paytabs Server Key";
    config.ProfileId = "Paytabs Profile Id";
    config.HideShipping = true;
    config.EnableIFrame = true;
});



// in case .NET 6
builder.Services.AddPaytabs(config => {
    config.ServerKey = "Paytabs Server Key";
    config.ProfileId = "Paytabs Profile Id";
    config.HideShipping = true;
    config.EnableIFrame = true;
});


// Alert: Server Key and Profile Id is a sensitive settings make sure to store them into
// a secret manager (Azure key vault for example).
// DON'T STORE SECRETS IN CODE
```

### Simple Example

```c#
public class TestPaymentService
{
    private readonly IPaytabsTransaction _paytabsTransaction;

    public TestPaymentService(IPaytabsTransaction paytabsTransaction)
    {
        _paytabsTransaction = paytabsTransaction;
    }

    public async Task<PaymentResponse> NewPayment(CancellationToken cancellationToken)
    {
        PaymentRequest paymentRequest = new PaymentRequest()
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
    }


    public async Task<QueryReferenceResponse> QueryPayment(CancellationToken cancellationToken)
    {
        QueryReferenceRequest request = new() { TransactionReference = "TST2212001212417" };
        return await _paytabsTransaction.MakeInquire(request,cancellationToken);
    }


    public async Task<QueryTokenResponse> QueryPaymentByToken(CancellationToken cancellationToken)
    {
        QueryTokenRequest request = new() { Token = "2C4651BF67A3EC34C6B691F8638B75BC" };
        return await _paytabsTransaction.MakeInquire(request, cancellationToken);
    }


    public async Task<DeleteTokenResponse> DeleteTokenPayment(CancellationToken cancellationToken)
    {
        DeleteTokenRequest request = new() { Token = "2C4651BF67A3EC34C6B691F8638B75BC" };
        return await _paytabsTransaction.DeleteToken(request, cancellationToken);
    }

}
```

## License

This project is licensed under the Apache 2.0 license.

## Contact

If you have any suggestions, comments or questions, please feel free to contact me on:

Email: motaz_ali@hotmail.com

[cash-in-package]: https://www.nuget.org/packages/Paytabs.SDK/
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[di-config-ref]: https://github.com/xshaheen/xdot-paymob/blob/main/src/CashIn.DependencyInjection/ServiceCollectionExtensions.cs#L58
