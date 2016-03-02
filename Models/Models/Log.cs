using System.Collections.Generic;

namespace Models
{
    static class Log
    {
        public static List<string> Records = new List<string>();

        public static void Write(string description)
        {
            Records.Add(description);
        }

        public static void Clear()
        {
            Records.Clear();
        }
    }
}
