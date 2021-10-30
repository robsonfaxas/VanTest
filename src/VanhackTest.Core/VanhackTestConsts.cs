using VanhackTest.Debugging;

namespace VanhackTest
{
    public class VanhackTestConsts
    {
        public const string LocalizationSourceName = "VanhackTest";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "42798aede0e543db9f08b1ba2dd7164b";
    }
}
