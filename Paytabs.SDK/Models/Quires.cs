// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using System.Text.Json.Serialization;

namespace Paytabs.SDK.Models
{
    public class QueryReferenceRequest
    {
        [JsonPropertyName("profile_id")]
        public long? ProfileId { get; set; } = null;

        [JsonPropertyName("tran_ref")]
        public string TransactionReference { get; set; }
    }


    public class QueryReferenceResponse : BaseTransactionResponse { }

    /*public class QueryReferenceResponse
    {
        [JsonPropertyName("profileId")]
        public long ProfileId { get; set; }

        [JsonPropertyName("tran_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("tran_ref")]
        public string TransactionReference { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("cart_id")]
        public string CartId { get; set; }

        [JsonPropertyName("cart_description")]
        public string CartDescription { get; set; }

        [JsonPropertyName("cart_currency")]
        public string CartCurrency { get; set; } = "EGP";

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

        [JsonPropertyName("shipping_details")]
        public ShippingDetails ShippingDetails { get; set; }

        [JsonPropertyName("payment_result")]
        public PaymentResult PaymentResult { get; set; }

        [JsonPropertyName("payment_info")]
        public PaymentInfo PaymentInfo { get; set; }
    }*/

    public class QueryTokenRequest
    {
        [JsonPropertyName("profile_id")]
        public long? ProfileId { get; set; } = null;

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }

    public class QueryTokenResponse : BaseTransactionResponse { }


    /*public class QueryTokenResponse
    {
        [JsonPropertyName("profileId")]
        public long ProfileId { get; set; }

        [JsonPropertyName("tran_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("tran_ref")]
        public string TransactionReference { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("cart_id")]
        public string CartId { get; set; }

        [JsonPropertyName("cart_description")]
        public string CartDescription { get; set; }

        [JsonPropertyName("cart_currency")]
        public string CartCurrency { get; set; } = "EGP";

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

        [JsonPropertyName("shipping_details")]
        public ShippingDetails ShippingDetails { get; set; }

        [JsonPropertyName("payment_result")]
        public PaymentResult PaymentResult { get; set; }

        [JsonPropertyName("payment_info")]
        public PaymentInfo PaymentInfo { get; set; }
    }*/


    public class DeleteTokenRequest
    {
        [JsonPropertyName("profile_id")]
        public long? ProfileId { get; set; } = null;

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }


    public class DeleteTokenResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }


}
