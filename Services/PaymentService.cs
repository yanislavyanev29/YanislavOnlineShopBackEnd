﻿using Stripe;
using YanislavOnlineShopBackEnd.Models;

namespace YanislavOnlineShopBackEnd.Services
{
    public class PaymentService
    {

        private readonly IConfiguration _config;
        public PaymentService(IConfiguration config)
        {
            _config = config;
        }


        public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Basket basket)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var service = new PaymentIntentService();

            var intent = new PaymentIntent();

            var subtotal = basket.Items.Sum(item => item.Quantity * item.Product.Price);

            var deliveryFee = subtotal > 300 ? 0 : 8;

            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long?)(subtotal + deliveryFee),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long?)(subtotal + deliveryFee)
                };
                await service.UpdateAsync(basket.PaymentIntentId, options); 

            }

            return intent;
        }
    }
}
