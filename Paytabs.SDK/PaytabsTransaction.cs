// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using Microsoft.Extensions.Options;
using Paytabs.SDK.Interfaces;
using Paytabs.SDK.Models;
using Paytabs.SDK.Utilities;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Paytabs.SDK
{
    public partial class PaytabsTransaction : IPaytabsTransaction
    {
        private readonly HttpService _httpService;
        private readonly PaytabsConfig _paytabsConfig;
        public PaytabsTransaction(HttpService httpService, IOptionsMonitor<PaytabsConfig> options)
        {
            _httpService = httpService;
            _paytabsConfig = options.CurrentValue;
        }
        public async Task<PaymentResponse> CreatePayment(PaymentRequest paymentRequest, CancellationToken cancellationToken)
        {
            ValidatePaytabsConfigData();
            ValidatePaymentRequestData(paymentRequest);
            paymentRequest = InsertConfigDefualtValuesForPaymentRequest(paymentRequest);

            var uri = PaytabsConfig.BaseURL + PaytabsConfig.RequestEndpoint;
            var result = await _httpService.Call(HttpMethod.Post,uri, paymentRequest, _paytabsConfig.ServerKey,cancellationToken);
            if (!result.IsSuccessStatusCode) 
                throw new Exception("Error in create payment request >> Message from Paytabs " + await result.Content.ReadAsStringAsync() );

            var response = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<PaymentResponse>(response);
        }

        public async Task<DeleteTokenResponse> DeleteToken(DeleteTokenRequest deleteTokenRequest, CancellationToken cancellationToken)
        {
            ValidatePaytabsConfigData();
            ValidateDeleteTokenRequestData(deleteTokenRequest);
            deleteTokenRequest = InsertConfigDefualtValuesForDeleteTokenRequest(deleteTokenRequest);
            deleteTokenRequest.ProfileId = _paytabsConfig.ProfileId;
            var uri = PaytabsConfig.BaseURL + PaytabsConfig.TokenEndpoint + PaytabsConfig.DeleteTokenEndpoint;
            var result = await _httpService.Call(HttpMethod.Post, uri, deleteTokenRequest, _paytabsConfig.ServerKey, cancellationToken);
            if (!result.IsSuccessStatusCode) 
                throw new Exception("Error in make delete token request >> Message from Paytabs " + await result.Content.ReadAsStringAsync());

            var response = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<DeleteTokenResponse>(response);
        }

        public async Task<QueryReferenceResponse> MakeInquire(QueryReferenceRequest queryReferenceRequest, CancellationToken cancellationToken)
        {
            ValidatePaytabsConfigData();
            ValidateQueryReferenceRequestData(queryReferenceRequest);
            queryReferenceRequest = InsertConfigDefualtValuesForQueryReferenceRequest(queryReferenceRequest);
            queryReferenceRequest.ProfileId = _paytabsConfig.ProfileId;
            var uri = PaytabsConfig.BaseURL + PaytabsConfig.QueryEndpoint;
            var result = await _httpService.Call(HttpMethod.Post, uri, queryReferenceRequest, _paytabsConfig.ServerKey, cancellationToken);
            if (!result.IsSuccessStatusCode) 
                throw new Exception("Error in make reference inquire request >> message from Paytabs " + await result.Content.ReadAsStringAsync());

            var response = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<QueryReferenceResponse>(response);
        }

        public async Task<QueryTokenResponse> MakeInquire(QueryTokenRequest queryTokenRequest, CancellationToken cancellationToken)
        {
            ValidatePaytabsConfigData();
            ValidateQueryTokenRequestData(queryTokenRequest);
            queryTokenRequest = InsertConfigDefualtValuesForQueryTokenRequest(queryTokenRequest);
            queryTokenRequest.ProfileId = _paytabsConfig.ProfileId;
            var uri = PaytabsConfig.BaseURL + PaytabsConfig.TokenEndpoint;
            var result = await _httpService.Call(HttpMethod.Post, uri, queryTokenRequest, _paytabsConfig.ServerKey, cancellationToken);
            if (!result.IsSuccessStatusCode) 
                throw new Exception("Error in make token inquire request >> Message from Paytabs " + await result.Content.ReadAsStringAsync());

            var response = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<QueryTokenResponse>(response);
        }
    }


    public partial class PaytabsTransaction
    {

        public void ValidatePaytabsConfigData()
        {
            if (_paytabsConfig.ServerKey == null || _paytabsConfig.ServerKey == "") throw new Exception("Server Key can't be null or empty, you can find Server Key from Paytabs dashboard");
            if (_paytabsConfig.ProfileId == null || _paytabsConfig.ProfileId <= 0) throw new Exception("profile ID can't be empty or Zero, you can find Profile ID from Paytabs dashboard");            
        }

        public void ValidatePaymentRequestData(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null) throw new Exception("Payment request object can't be null, please provide payment request data");
            if (paymentRequest.CartAmount <= 0) throw new Exception("Cart amount can't be zero or negative number");            
        }

        private void ValidateQueryReferenceRequestData(QueryReferenceRequest queryReferenceRequest) 
        {
            if (queryReferenceRequest.TransactionReference == null || queryReferenceRequest.TransactionReference == "") throw new Exception("Query reference can't be null or empty");
        }

        private void ValidateQueryTokenRequestData(QueryTokenRequest queryTokenRequest)
        {
            if (queryTokenRequest.Token == null || queryTokenRequest.Token == "") throw new Exception("Query token can't be null or empty");
        }


        private void ValidateDeleteTokenRequestData(DeleteTokenRequest deleteTokenRequest)
        {
            if (deleteTokenRequest.Token == null || deleteTokenRequest.Token == "") throw new Exception("Delete token can't be null or empty");
        }


        public PaymentRequest InsertConfigDefualtValuesForPaymentRequest(PaymentRequest paymentRequest) 
        {
            if (paymentRequest.ProfileId == null || paymentRequest.ProfileId <= 0)
                paymentRequest.ProfileId = _paytabsConfig.ProfileId;

            if(paymentRequest.HideShipping == null)
                paymentRequest.HideShipping = _paytabsConfig.HideShipping;

            if (paymentRequest.EnableIFrame == null)
                paymentRequest.EnableIFrame = _paytabsConfig.EnableIFrame;

            if (paymentRequest.CallbackUrl == null)
                paymentRequest.CallbackUrl = _paytabsConfig.CallbackUrl;

            if (paymentRequest.ReturnUrl == null)
                paymentRequest.ReturnUrl = _paytabsConfig.ReturnUrl;

            return paymentRequest;
        }


        public QueryReferenceRequest InsertConfigDefualtValuesForQueryReferenceRequest(QueryReferenceRequest queryReferenceRequest)
        {
            if (queryReferenceRequest.ProfileId == null || queryReferenceRequest.ProfileId <= 0)
                queryReferenceRequest.ProfileId = _paytabsConfig.ProfileId;

            return queryReferenceRequest;
        }


        public QueryTokenRequest InsertConfigDefualtValuesForQueryTokenRequest(QueryTokenRequest queryTokenRequest)
        {
            if (queryTokenRequest.ProfileId == null || queryTokenRequest.ProfileId <= 0)
                queryTokenRequest.ProfileId = _paytabsConfig.ProfileId;

            return queryTokenRequest;
        }


        public DeleteTokenRequest InsertConfigDefualtValuesForDeleteTokenRequest(DeleteTokenRequest deleteTokenRequest)
        {
            if (deleteTokenRequest.ProfileId == null || deleteTokenRequest.ProfileId <= 0)
                deleteTokenRequest.ProfileId = _paytabsConfig.ProfileId;

            return deleteTokenRequest;
        }

    }
}
