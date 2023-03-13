using UnityEngine;
namespace Structures
{
    public class SORange<T> : ScriptableObject
    {
        [SerializeField] private T _min;
        [SerializeField] private T _max;

        public T Min => _min;
        public T Max => _max;
    }
}
