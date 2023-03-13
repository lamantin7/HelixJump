using UnityEngine;
using Structures;

[CreateAssetMenu(menuName ="ScriptableObjects/Tower/TowerGenerationSettings",fileName ="TowerGenerationSettings")]
public class SOTowerGenerationSettings : ScriptableObject
{
    [SerializeField][Min(0)] private int _platformVariantCount;
    [SerializeField][Min(0f)] private float _offsetBetweenPlatforms;

    [SerializeField] private FloatRange _rotationRange;

    [Header("Platform Prefabs")]
    [SerializeField] private Platform _startPlatformPrefab;
    [SerializeField] private Platform _finishPlatformPrefab;
    [SerializeField] private Platform[] _platformVariantPrefabs;

    public int PlatformVariantCount => _platformVariantCount;
    public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;
    public Platform StartPlatformPrefab => _startPlatformPrefab;
    public Platform FinishPlatformPrefab => _finishPlatformPrefab;
    public Platform PlatformVariantPrefabs => _platformVariantPrefabs.Random();
    public FloatRange RotationRange => _rotationRange;
}
