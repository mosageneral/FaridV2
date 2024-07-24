using FaridV2.Debugging;

namespace FaridV2
{
    public class FaridV2Consts
    {
        public const string LocalizationSourceName = "FaridV2";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "9fc7bd42a24e468689a746dcbfcc5923";
    }
}
