using System;

namespace Utils
{

    public static class InvariantChecker
    {
        public static void CheckObjectInvariant(params object[] args)
        {
            foreach (var arg in args)
            {
                if (arg == null)
                    throw new NullReferenceException();
            }
        }

        public static void CheckPercentageInvariant(params float[] args)
        {
            foreach (var arg in args)
            {
                if (arg < 0 || arg > 100)
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}