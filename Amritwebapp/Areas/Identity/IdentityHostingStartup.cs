using System;
using Amritwebapp.Areas.Identity.Data;
using Amritwebapp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Amritwebapp.Areas.Identity.IdentityHostingStartup))]
namespace Amritwebapp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AmritwebappContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AmritwebappContextConnection")));

                services.AddDefaultIdentity<AmritwebappUser>()
                    .AddEntityFrameworkStores<AmritwebappContext>();
            });
        }
    }
}