// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using System;
using System.Collections.Generic;
using System.Text;

namespace Paytabs.SDK.Models
{
    public class PaytabsConfig
    {
        public static string BaseURL { get; } = "https://secure-egypt.paytabs.com/payment";
        public static string RequestEndpoint { get; } = "/request";
        public static string QueryEndpoint { get; } = "/query";
        public static string TokenEndpoint { get; } = "/token";

        public static string DeleteTokenEndpoint { get; } = "/delete";

        public string ServerKey { get; set; } = null;
        public long? ProfileId { get; set; } = null;
        public bool? HideShipping { get; set; } = null;
        public bool? EnableIFrame { get; set; } = true;
        public string CallbackUrl { get; set; } = "none";
        public string ReturnUrl { get; set; } = "none";
    }
}
