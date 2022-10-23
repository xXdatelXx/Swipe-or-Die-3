using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class TweenExtension
    {
        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOCircleRotateZ(this Transform t,
            float duration)
        {
            return DORotateZ(t, 360, duration, RotateMode.FastBeyond360);
        }

        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotateZ(this Transform t, float z,
            float duration, RotateMode mode = RotateMode.Fast)
        {
            return t.DORotate(new Vector3(0, 0, z), duration, mode);
        }

        public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotateX(this Transform t, float x,
            float duration, RotateMode mode = RotateMode.Fast)
        {
            return t.DORotate(new Vector3(x, 0, 0), duration, mode);
        }

        public static T Looped<T>(this T t) where T : Tween => 
            t.SetLoops(-1);
    }
}