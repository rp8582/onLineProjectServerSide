using BL.manager;
using BL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Token
    {
        private static JWTContainerModel getJWTContainerModel(string name,string phone)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.MobilePhone,phone),
                }
            };
        }

        public static string GetToken(string name,string phone)
        {
            IAuthContainerModel model = getJWTContainerModel(name, phone);
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);
           
            return token;
        }
        
        public static string GetPhoneFromToken(string token)
        {
            string tokenPhone;
            IAuthContainerModel model = new JWTContainerModel();

            IAuthService authService = new JWTService(model.SecretKey);

            /*if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {*/
                List<Claim> claims = authService.GetTokenClaims(token).ToList();

                string tokenName = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                tokenPhone = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.MobilePhone)).Value;
                
            //}
            return tokenPhone;
        }
    }
}
