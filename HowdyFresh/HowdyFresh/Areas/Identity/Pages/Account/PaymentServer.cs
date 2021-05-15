using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

public class StripeOptions

{

    public string option { get; set; }

}

namespace server.Controllers

{

    public class Program

    {

        public static void PaymentMain(string[] args)

        {

            WebHost.CreateDefaultBuilder(args)

              .UseUrls("http://0.0.0.0:4242")

              .UseWebRoot(".")

              .UseStartup<Startup>()

              .Build()

              .Run();

        }

    }

    public class Startup

    {

        public void ConfigureServices(IServiceCollection services)

        {

            services.AddMvc().AddNewtonsoftJson();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {

            // This is a sample test API key. Sign in to see examples pre-filled with your key.

            StripeConfiguration.ApiKey = "pk_test_51IrRpKJWi52jsatBdENaLIyqc1t7ER8zM8SFpGlPQHVuqwrcb9aBKWXXtopYGdBo9a3tdCkWOBdYWVjHhJtIre2Y00Ey4fpLob";

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }

    }

    [Route("create-checkout-session")]

    [ApiController]

    public class CheckoutApiController : Controller

    {

        [HttpPost]

        public ActionResult Create()

        {

            var domain = "http://localhost:4242";

            var options = new SessionCreateOptions

            {

                PaymentMethodTypes = new List<string>

                {

                  "card",

                },

                LineItems = new List<SessionLineItemOptions>

                {

                  new SessionLineItemOptions

                  {

                    PriceData = new SessionLineItemPriceDataOptions

                    {

                      UnitAmount = 2000,

                      Currency = "usd",

                      ProductData = new SessionLineItemPriceDataProductDataOptions

                      {

                        Name = "Stubborn Attachments",

                      },

                    },

                    Quantity = 1,

                  },

                },

                Mode = "payment",

                SuccessUrl = domain + "/success.html",

                CancelUrl = domain + "/cancel.html",

            };

            var service = new SessionService();

            Session session = service.Create(options);

            return Json(new { id = session.Id });

        }

    }

}
