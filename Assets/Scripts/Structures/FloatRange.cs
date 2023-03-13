using System;
using System.Collections.Generic;
using UnityEngine;

namespace Structures
{
    [CreateAssetMenu(menuName ="ScriptableObjects/Structures/FloatRange", fileName="FloatRange")]
    public class FloatRange:SORange<float>
    {  

        public float Random =>UnityEngine.Random.Range(Min,Max);
    }
}
