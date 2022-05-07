// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.

using System;
using System.Text.Json.Serialization;

namespace Paytabs.SDK.Models
{
    public class PaymentRequest
    {
        [JsonPropertyName("profile_id")]
        public long? ProfileId { get; set; } = null;

        [JsonPropertyName("tran_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("tran_class")]
        public string TransactionClass { get; set; }

        [JsonPropertyName("tran_currency")]
        public string TransactionCurrency { get; set; } = "EGP";


        /// <summary>
        /// The parameter "tokenise" is an optional parameter, where you need to pass, only if you want to save a transaction's token, for further usage such as the used one in the recurring requests.
        /// </summary>
        [JsonPropertyName("tokenise")]
        public string Tokenise { get; set; } = null ;

        [JsonPropertyName("show_save_card")]
        public bool ShowSaveCard { get; set; } = false;

        [JsonPropertyName("cart_id")]
        public string CartId { get; set; }

        [JsonPropertyName("cart_description")]
        public string CartDescription { get; set; }

        [JsonPropertyName("cart_currency")]
        public string CartCurrency { get; set; } = "EGP";

        [JsonPropertyName("cart_amount")]
        public double CartAmount { get; set; } = 0.0;

        [JsonPropertyName("callback")]
        public string CallbackUrl { get; set; } = null;

        [JsonPropertyName("return")]
        public string ReturnUrl { get; set; } = null;

        [JsonPropertyName("payment_token")]
        public string PaymentToken { get; set; } = null;

        [JsonPropertyName("hide_shipping")]
        public bool? HideShipping { get; set; } = null;

        [JsonPropertyName("framed")]
        public bool? EnableIFrame { get; set; } = null;

        [JsonPropertyName("customer_details")]
        public CustomerDetails CustomerDetails { get; set; }


        /// <summary>
        /// Card Details, note: you should provide PCI DSS certification to a minimum of SAQ-D is required
        /// </summary>
        [JsonPropertyName("card_details")]
        public CardDetails CardDetails { get; set; } = null;

    }


    public class CustomerDetails 
    {
        [JsonPropertyName("name")]
        public string Fullname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("street1")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
        
        [JsonPropertyName("ip")]
        public string IP { get; set; }
    }


    public class ShippingDetails
    {
        [JsonPropertyName("name")]
        public string Fullname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("street1")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("ip")]
        public string IP { get; set; }
    }



    public class CardDetails
    {
        [JsonPropertyName("pan")]
        public string CardNumbers { get; set; }

        [JsonPropertyName("cvv")]
        public string CVV { get; set; }

        [JsonPropertyName("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonPropertyName("expiry_year")]
        public int ExpiryYear { get; set; }
    }

    /*public abstract class BasePaymentResponse
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

        [JsonPropertyName("payment_result")]
        public PaymentResult PaymentResult { get; set; }

        [JsonPropertyName("payment_info")]
        public PaymentInfo PaymentInfo { get; set; }
    }*/

    public class PaymentResponse : BaseTransactionResponse { }

    /*public class PaymentResponse 
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

        [JsonPropertyName("payment_result")]
        public PaymentResult PaymentResult { get; set; }

        [JsonPropertyName("payment_info")]
        public PaymentInfo PaymentInfo { get; set; }
    }*/


    public class PaymentResult 
    {
        [JsonPropertyName("response_status")]
        public string ResponseStatus { get; set; }

        [JsonPropertyName("response_code")]
        public string ResponseCode { get; set; }

        [JsonPropertyName("response_message")]
        public string ResponseMessage { get; set; }

        [JsonPropertyName("acquirer_message")]
        public string AcquirerMessage { get; set; }

        [JsonPropertyName("acquirer_rrn")]
        public string AcquirerRRN { get; set; }

        [JsonPropertyName("cvv_result")]
        public string CVVResult { get; set; }

        [JsonPropertyName("avs_result")]
        public string AVSResult { get; set; }

        [JsonPropertyName("transaction_time")]
        public string TransactionTime { get; set; }
    }


    public class PaymentInfo
    {
        [JsonPropertyName("card_type")]
        public string CardType { get; set; }

        [JsonPropertyName("card_scheme")]
        public string CardScheme { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("payment_description")]
        public string PaymentDescription { get; set; }

        [JsonPropertyName("expiryMonth")]
        public int ExpiryMonth { get; set; }

        [JsonPropertyName("expiryYear")]
        public int ExpiryYear { get; set; }

        [JsonPropertyName("IssuerCountry")]
        public string IssuerCountry { get; set; }

        [JsonPropertyName("IssuerName")]
        public string IssuerName { get; set; }

    }


    public class CallbackResponse :BaseTransactionResponse {}

}
