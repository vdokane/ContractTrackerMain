using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ContractTracker.Common.SecurityModels;

namespace ContractTracker.Common.Functionality
{
    public interface ITokenBuilder
    {
        string BuildToken(CommonAuthenticatedUserModel commonAuthenticatedUserModel);
    }
    public class TokenBuilder : ITokenBuilder
    {
        private readonly string _issuer;
        private readonly string _audience;
        private const string _sec = "themoreofyouthatiinspectthemoreofmeiseereflect";  //Again, this should be a super duper secret and not checked in to a public repo
        public TokenBuilder(string issuer, string audience)
        {
            _issuer = issuer;
            _audience = audience;
        }
        public TokenBuilder() //Shouldnt be using this one. Should be environment specific
        {
            _issuer = "http://localhost:25940"; //This is API app
            _audience = "http://localhost:58007"; //This is web UI
        }
        public string BuildToken(CommonAuthenticatedUserModel commonAuthenticatedUserModel)
        {

            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, commonAuthenticatedUserModel.UserName),
            });

            DateTime now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(_sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: _issuer, audience: _audience,
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public void ParseToken(string strJWTToken)
        {

            //JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(strJWTToken);

            byte[] key = System.Text.Encoding.Default.GetBytes(_sec);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken securityToken = handler.ReadJwtToken(strJWTToken); //Might want to put this in a try catch to make sure they aren't sending in junk


            SecurityToken tokenSecure = handler.ReadToken(strJWTToken);
            TokenValidationParameters validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            ClaimsPrincipal claims = handler.ValidateToken(strJWTToken, validations, out tokenSecure);
            var test = claims.Identity.Name;
            var test2 = claims.Identities; //It is all buried down in here
            //Still need to clean this up
            foreach (Claim claim in claims.Claims)
            {
                string tst = claim.Type;
                string tst2 = claim.Subject.Name;
                string tst3 = claim.Subject.NameClaimType;
            }

        }

        public void ParseTokenBetter(string strJWTToken)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(strJWTToken);

            var tstClaimNI = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier);
            var tstClaimN = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Name);
            var tstClaimRole = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Role);
            var tstClaimEmail = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Email);


            foreach (Claim claim in jwtSecurityToken.Claims)
            {
                var tst = claim;
                string tst5 = claim.Type;
                string tst4 = claim.Value;
                if (claim.Type == ClaimTypes.NameIdentifier)
                {
                    var shouldBeEmail = claim.Value;
                }
                else if (claim.Type == ClaimTypes.Role)
                {
                    var shouldBeRole = claim.Value;
                }
                else if (claim.Type == ClaimTypes.Name)
                {
                    var shouldBeName = claim.Value;
                }
                //string tst2 = claim.Subject.Name;
                //string tst3 = claim.Subject.NameClaimType;
            }
            //I could return a userModel here with the claims
            //I could return some of these claims to store in session storage or should the whole JWT get saved
        }

        public IEnumerable<Claim> GetClaimsFromToken(string strJWTToken)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(strJWTToken);
            return jwtSecurityToken.Claims;

        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
