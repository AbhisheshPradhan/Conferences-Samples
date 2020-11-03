﻿using Microsoft.Identity.Client;
using System;
using System.Security;
using System.Threading.Tasks;


namespace MSALAADB2C
{
    class Program
    {
        // ID of the App registered in AAD B2C
        private static string clientId = "0a3ba30d-f47f-411e-8015-8cbb923dc41f";

        // Authority
        private static string authority = "https://piasysdevb2c.b2clogin.com/tfp/piasysdevb2c.onmicrosoft.com/B2C_1_SignIn/oauth2/v2.0/token";

        // Permission scopes
        private static string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

        static async Task Main(string[] args)
        {
            IPublicClientApplication app = PublicClientApplicationBuilder.Create(clientId)
                  .WithB2CAuthority(authority)
                  .WithRedirectUri("http://localhost")
                  .Build();

            try
            {
                Console.WriteLine("Getting delegated access token...");
                AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

                Console.WriteLine(result.AccessToken);
            }
            catch (MsalException exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.Read();
        }
    }
}
