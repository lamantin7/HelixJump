using UnityEngine;

namespace Extension
{
    public static class TransformExtension
    {
        public static void ClearParent(this Transform transform) =>
            transform.SetParent(null);
    }
}
