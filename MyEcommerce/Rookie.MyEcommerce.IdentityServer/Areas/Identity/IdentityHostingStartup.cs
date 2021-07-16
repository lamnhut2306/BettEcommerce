using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rookie.MyEcommerce.IdentityServer.Data;
using Rookie.MyEcommerce.IdentityServer.Models;

[assembly: HostingStartup(typeof(Rookie.MyEcommerce.IdentityServer.Areas.Identity.IdentityHostingStartup))]
namespace Rookie.MyEcommerce.IdentityServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}