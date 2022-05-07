// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.


using Paytabs.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paytabs.SDK.Interfaces
{
    public interface IPaytabsTransaction
    {
        /// <summary>
        /// Create new payment request and return the iframe of the payment gate url and some details
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaymentResponse> CreatePayment(PaymentRequest paymentRequest, CancellationToken cancellationToken);
        
        /// <summary>
        /// Make a query by Transaction Reference to know the details of that transaction  
        /// </summary>
        /// <param name="queryRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QueryReferenceResponse> MakeInquire(QueryReferenceRequest queryRequest, CancellationToken cancellationToken);

        /// <summary>
        /// Make a query by Token to know the details of that transaction 
        /// </summary>
        /// <param name="queryTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QueryTokenResponse> MakeInquire(QueryTokenRequest queryTokenRequest, CancellationToken cancellationToken);
        
        /// <summary>
        /// Delete Token that created from payment request client 
        /// </summary>
        /// <param name="deleteTokenRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DeleteTokenResponse> DeleteToken(DeleteTokenRequest deleteTokenRequest, CancellationToken cancellationToken);


    }
}
