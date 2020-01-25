using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Vector2Extensions
    {
        // ReSharper disable once InconsistentNaming
        public static Vector3 xz(this Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        } 
    }
}
