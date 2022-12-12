using System;

namespace Assets.Core.Engine
{
    public static class Debug
    {
        public static event Action<string> log;

        public static void Log(object obj)
        {
            log(obj.ToString());
        }
    }
}
