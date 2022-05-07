// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Paytabs.SDK.Models
{
    public static class TransactionType
    {
        public static readonly string AUTH = "auth";
        public static readonly string SALE = "sale";
        public static readonly string VERIFY = "verify";
        public static readonly string CAPTURE = "capture";
        public static readonly string VOID = "void";
        public static readonly string REFUND = "refund";
        public static readonly string QUERY = "query";
        public static readonly string REPORTS = "reports";
        public static readonly string INVOICE = "invoice";
        public static readonly string PAYOUT = "payout";
    }


    /// <summary>
    /// The Transaction Class is responsible to identify the class of a transaction such as ECommerce, Recurring , etc.
    /// </summary>
    public static class TransactionClass
    {
        /// <summary>
        /// The initial request to create any payment page should be with class "ecom", which indicates to eCommerce
        /// </summary>
        public static readonly string ECOM = "ecom";
        /// <summary>
        /// The moto class is meant to be used to process the request/payment with "Non 3DS" and/or "Non CVV".
        /// </summary>
        public static readonly string MOTO = "moto";

        /// <summary>
        /// This can be used to allow returning customers to purchase without re-entering credit card details (recurring) such as monthly subscriptions fees. 
        /// Once you have the token from the initial payment response, you can do a new request and pass the token number as "token" in case you need to perform recurring action.
        /// </summary>
        public static readonly string RECURRING = "recurring";
    }


    /// <summary>
    /// The "tokenise" type is an optional parameter, where you need to pass, only if you want to save a transaction's token, for further usage such as the used one in the recurring requests.
    /// </summary>
    public static class TokeniseType 
    {
        public static readonly string Hex32 = "2";
        public static readonly string AlphaNum20 = "3";
        public static readonly string Digit22 = "4";
        public static readonly string Digit16 = "5";
        public static readonly string AlphaNum32 = "6";
    }


    public abstract class BaseTransactionResponse
    {
        [JsonPropertyName("profileId")]
        public long ProfileId { get; set; }

        [JsonPropertyName("tran_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("tran_ref")]
        public string TransactionReference { get; set; }

        [JsonPropertyName("tran_currency")]
        public string TransactionCurrency { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("cart_id")]
        public string CartId { get; set; }

        [JsonPropertyName("cart_description")]
        public string CartDescription { get; set; }

        [JsonPropertyName("cart_currency")]
        public string CartCurrency { get; set; }

        [JsonPropertyName("cart_amount")]
        public string CartAmount { get; set; }

        [JsonPropertyName("callback")]
        public string CallbackUrl { get; set; }

        [JsonPropertyName("return")]
        public string ReturnUrl { get; set; }

        [JsonPropertyName("redirect_url")]
        public string IFRameRedirectUrl { get; set; }

        [JsonPropertyName("serviceId")]
        public long ServiceId { get; set; }

        [JsonPropertyName("merchantId")]
        public long MerchantId { get; set; }

        [JsonPropertyName("trace")]
        public string Trace { get; set; }

        [JsonPropertyName("customer_details")]
        public CustomerDetails CustomerDetails { get; set; }

        [JsonPropertyName("payment_result")]
        public PaymentResult PaymentResult { get; set; }

        [JsonPropertyName("payment_info")]
        public PaymentInfo PaymentInfo { get; set; }
    }


}
