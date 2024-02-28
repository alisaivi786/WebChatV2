namespace WebChat.Application.Auth
{
    public interface IIdentityUser
    {
        int UserId { get; }
        string UserName { get;}
        string NickName { get;}
        string UserPhoto { get;}
        DateTime LoginTime { get; }
        string LoginIPAddress { get; }
        TokenTypeEnum TokenType { get; }
        string Isvalidator { get; }
        int KeyCode { get; }
        int PhoneType { get; }
        int UserType { get;}

    }


    public class IdentityUser(IPrincipalAccessor principalAccessor) : IIdentityUser
    {
        protected IPrincipalAccessor PrincipalAccessor { get; set; } = principalAccessor;

        public int UserId => GetClaim(AuthClaimTypes.UserId).ToInt();
        public string UserName => GetClaim(AuthClaimTypes.UserName);
        public string NickName => GetClaim(AuthClaimTypes.NickName);
        public string UserPhoto => GetClaim(AuthClaimTypes.UserPhoto);
        public DateTime LoginTime => Convert.ToDateTime(GetClaim(AuthClaimTypes.LoginTime));
        public string LoginIPAddress => GetClaim(AuthClaimTypes.LoginIPAddress);
        public LoginMarkEnum LoginMark => (LoginMarkEnum)GetClaim(AuthClaimTypes.LoginMark).GetIntValueByEnum<LoginMarkEnum>();
        public TokenTypeEnum TokenType => (TokenTypeEnum)GetClaim(AuthClaimTypes.TokenType).GetIntValueByEnum<TokenTypeEnum>();
        public string Isvalidator => GetClaim(AuthClaimTypes.Isvalidator);
        public int KeyCode => GetClaim(AuthClaimTypes.KeyCode).ToInt();
        public int PhoneType => GetClaim(AuthClaimTypes.PhoneType).ToInt();
        public int UserType => GetClaim(AuthClaimTypes.UserType).ToInt();

        protected TValue GetClaim<TValue>(string key)
        {
            if (key.IsEmpty())
            {
                return default;
            }
            var claims = PrincipalAccessor.Principal?.Claims;
            if (claims.IsEmpty())
            {
                return default;
            }
            var stringValue = claims.FirstOrDefault(n => n.Type == key)?.Value;
            if (stringValue == null)
            {
                return default;
            }
            return (TValue)Convert.ChangeType(stringValue, typeof(TValue));
        }

        protected T GetClaimToObj<T>(string key) where T : class
        {
            if (key.IsEmpty())
            {
                return default(T);
            }
            var claims = PrincipalAccessor.Principal?.Claims;
            if (claims.IsEmpty())
            {
                return default(T);
            }
            var stringValue = claims.FirstOrDefault(n => n.Type == key)?.Value;
            if (stringValue == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        protected string GetClaim(string key)
        {
            return GetClaim<string>(key);
        }
    }

}
