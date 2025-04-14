namespace CareerCompass.Services.Helpers
{
    internal static class ComparatorHelper
    {
        public static bool ExplicitEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;

            if (diff != 0)
            {
                return false;
            }

            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }
    }
}
