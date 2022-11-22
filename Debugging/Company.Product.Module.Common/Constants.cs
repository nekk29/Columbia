namespace Company.Product.Module.Common
{
    public class Constants
    {
        public struct Culture
        {
            public const string enUSCulture = "en-US";
            public const string esESCulture = "es-ES";
        }

        public struct Security
        {
            public struct User
            {
                public const string Administrator = "administrator";
            }

            public struct ClaimTypes
            {
                public const string Role = "role";
            }
        }

        public struct Email
        {
            public struct User
            {
                public const string Registration = "User.Registration";
                public const string ResetPassword = "User.ResetPassword";
            }
        }
    }
}
