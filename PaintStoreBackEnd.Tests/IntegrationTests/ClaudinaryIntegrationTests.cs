using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PaintStore.Domain.UploadModels;

namespace PaintStore.Tests.IntegrationTests
{
    public class ClaudinaryIntegrationTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Test]
        public void GetCredentialsFromUpsetting_ValidData_Loaded()
        {
            var config = InitConfiguration();

            var cloudinaryCredentials = config.GetSection("AppIdentitySettings").Get<AppIdentitySettings>();

            Assert.Multiple(() =>
            {
                Assert.NotNull(cloudinaryCredentials.ApiKey);
                Assert.NotNull(cloudinaryCredentials.CouldName);
                Assert.NotNull(cloudinaryCredentials.SecretApiKey);
            });
        }

        [Test]
        public void ConnectToCloudinary_ValidData_Connected()
        {
            var config = InitConfiguration();
            var cloudinaryCredentials = config.GetSection("AppIdentitySettings").Get<AppIdentitySettings>();
            var account = new Account(){ ApiKey = cloudinaryCredentials.ApiKey,
                ApiSecret = cloudinaryCredentials.SecretApiKey, Cloud = cloudinaryCredentials.CouldName};
            var m_cloudinary = new Cloudinary(account);

            var tag = m_cloudinary.ListTags();

            Assert.Null(tag.Error);
        }

        [Test]
        public void ConnectToCloudinary_IncorrectCredentials_Connected()
        {
            var config = InitConfiguration();
            var cloudinaryCredentials = config.GetSection("AppIdentitySettings").Get<AppIdentitySettings>();
            var account = new Account(){ ApiKey = "definitelyNotValid",
                ApiSecret = "definitelyNotValid", Cloud = cloudinaryCredentials.CouldName};
            var m_cloudinary = new Cloudinary(account);

            var tag = m_cloudinary.ListTags();
            
            Assert.NotNull(tag.Error);
        }
    }
}
