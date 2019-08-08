using System.Security.Claims;

namespace Admin.Dist.Configs
{
    public static class TokenConfig
    {
        public const string UserName = ClaimTypes.Name;

        public const string ContactId = "cid";

        public const string UserId = "uid";

        public const string AccountId = "aid";

        public const string AccountName = "aname";

        public const string AgreementStatus = "agree";

        public const string CountryId = "countryid";

        public const string CountryName = "country";

        public const string LanguageId = "lang";

        public const string LanguageCode = "langcode";

        public const string AccountTypeId = "atypeid";

        public const string AccountTypeName = "atype";

        public const string TierId = "tierid";

        public const string TierName = "tiername";

        public const string NickName = "nickname";

        public const string ReadOnly = "read";
    }
}
