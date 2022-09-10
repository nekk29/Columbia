namespace Columbia.Dsl.Utils
{
    public class CommonConstants
    {
        public struct Projects
        {
            public const string vsProjectKindMiscCSharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
            public const string vsProjectKindMiscOther = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
        }

        public struct Strings
        {
            public const string Null = null;
            public const string Default = "";
            public const string Zero = "0";
            public const string Negative = "-1";
            public const string One = "1";
            public const string Separator = "-";
        }

        public struct Dates
        {
            public const string DefaultDate = "10-10-1900";
            public const string DefaultTime = "12:00";
            public const string DefaultDateTime = "01/01/0001 12:00:00 a.m.";
        }

        public struct Booleans
        {
            public const bool True = true;
            public const bool False = false;
        }

        public struct Numbers
        {
            public const int Zero = 0;
            public const int Five = 5;
        }
    }
}
