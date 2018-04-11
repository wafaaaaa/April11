﻿#define SingleTenantApp
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using CYJ.Utils;

namespace CYJ
{
    public partial class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        private static string authority = aadInstance + tenantId;

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            //app.UseOpenIdConnectAuthentication(
            //    new OpenIdConnectAuthenticationOptions
            //    {
            //        ClientId = clientId,
            //        Authority = authority,
            //        PostLogoutRedirectUri = postLogoutRedirectUri
            //    });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = ConfigHelper.ClientId,
#if SingleTenantApp
                    Authority = String.Format(CultureInfo.InvariantCulture, ConfigHelper.AadInstance, ConfigHelper.Tenant), // For Single-Tenant
#else
                    Authority = ConfigHelper.CommonAuthority, // For Multi-Tenant
#endif
                    PostLogoutRedirectUri = ConfigHelper.PostLogoutRedirectUri,

                    // Here, we've disabled issuer validation for the multi-tenant sample.  This enables users
                    // from ANY tenant to sign into the application (solely for the purposes of allowing the sample
                    // to be run out-of-the-box.  For a real multi-tenant app, reference the issuer validation in 
                    // WebApp-MultiTenant-OpenIDConnect-DotNet.  If you're running this sample as a single-tenant
                    // app, you can delete the ValidateIssuer property below.
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {
#if !SingleTenantApp
                        ValidateIssuer = false, // For Multi-Tenant Only
#endif
                        RoleClaimType = "roles",
                    },

                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Error/ShowError?signIn=true&errorMessage=" + context.Exception.Message);
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}
