using UnityEditor;
using UnityEngine;

namespace Platforms
{
    [CreateAssetMenu(fileName ="PlatformSettings", menuName ="ScriptableObjects/Platforms/PlatformSettings")]
    public class SOPlatformSettings : ScriptableObject
    {
        [SerializeField][Min(0f)] private float _destroyDelayAfterUnhooking;
        public float DestroyDelayAfterUnhooking => _destroyDelayAfterUnhooking;
    }
}