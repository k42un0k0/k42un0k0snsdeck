using System;
using System.Linq;

namespace K42un0k0SnsDeck.Common
{
    public class UtilMethods
    {
        public static UtilMethods Singleton = new UtilMethods();
        private readonly Random _random = new Random();

        public virtual long UnixTimeSeconds
        {
            get
            {
                return DateTimeOffset.Now.ToUnixTimeSeconds();
            }
        }

        public virtual string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
