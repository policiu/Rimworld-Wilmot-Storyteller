namespace WilmotStoryteller.Utilities
{
    internal class HarmonyUtility
    {
        #region Private Fields

        private static readonly string wilmotHarmonyPrefix = "io.github.policiu.wilmotstoryteller.";

        #endregion Private Fields

        #region Public Methods

        public static string GetHarmonyName(string suffix)
        {
            return wilmotHarmonyPrefix + suffix;
        }

        #endregion Public Methods
    }
}