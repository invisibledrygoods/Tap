using UnityEngine;
using System;

namespace Tap {
    public static class Tap
    {
        public static T Tap<T>(this T tap, Action<T> act)
        {
            act(tap);
            return tap;
        }

        public static T Log<T>(this T tap)
        {
            Debug.Log(tap);
            return tap;
        }

        public static T Log<T, S>(this T tap, Func<T, S> func)
        {
            Debug.Log(func(tap));
            return tap;
        }

        public static void AndAnd<T>(this T tap, Action<T> act)
        {
            if (tap != null)
            {
                act(tap);
            }
        }

        public static S AndAnd<T, S>(this T tap, Func<T, S> func)
        {
            if (tap == null || tap is UnityEngine.Object && !(tap as UnityEngine.Object))
            {
                return default(S);
            }

            return func(tap);
        }
    }
}