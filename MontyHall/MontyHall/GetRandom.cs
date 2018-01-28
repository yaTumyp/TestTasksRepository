using System;

using System.Security.Cryptography;

namespace MontyHall
{
    public static class GetRandom
    {
        private static Random _random;

        public static int Next(int min, int max)
        {
            if (_random == null)
            {
                var cryptoResult = new byte[4];
                new RNGCryptoServiceProvider().GetBytes(cryptoResult);

                int seed = BitConverter.ToInt32(cryptoResult, 0);

                _random = new Random(seed);
            }
            return _random.Next(min, max);
        }
    }
}
