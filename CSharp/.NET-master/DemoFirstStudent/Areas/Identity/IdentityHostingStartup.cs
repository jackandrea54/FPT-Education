﻿using System;
using DemoFirstStudent.Areas.Identity.Data;
using DemoFirstStudent.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DemoFirstStudent.Areas.Identity.IdentityHostingStartup))]
namespace DemoFirstStudent.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<UsingIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

                services.AddDefaultIdentity<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UsingIdentityContext>();
            });
        }
    }
}