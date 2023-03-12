
using System;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private Platform _finishPlatform;
    [SerializeField] private Platform[] _platformVariants = Array.Empty<Platform>();
}
