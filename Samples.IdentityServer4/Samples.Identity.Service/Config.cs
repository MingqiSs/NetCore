using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Identity.Service
{
    public class Config
    {
        /// <summary>
        /// 定义 API 资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(
                    OAuthConfig.UserApi.ApiName,
                    OAuthConfig.UserApi.ApiName
                    ),
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
                 new ApiScope(name: OAuthConfig.UserApi.ApiName)
             };
        }
        /// <summary>
        /// 定义 API 资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }
        /// <summary>
        /// 定义 客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client()
               {
                   ClientId =OAuthConfig.UserApi.ClientId,
                   AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                   ClientSecrets = {new Secret(OAuthConfig.UserApi.Secret.Sha256()) },
                   AllowedScopes= { OAuthConfig.UserApi.ApiName},
                 //  AccessTokenLifetime = OAuthConfig.ExpireIn,
               },
            };
        }
        /// <summary>
        /// 测试的账号和密码
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
         {
            new TestUser()
            {
                 SubjectId = "1",
                 Username = "test",
                 Password = "password"
            },
            new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
