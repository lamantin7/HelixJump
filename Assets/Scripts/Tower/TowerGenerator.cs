
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] [Min(0)] private int _platformVariantCount;
    [SerializeField] [Min(0f)] private float _offsetBetweenPlatforms;

    [Header("Platform Rotation")]
    [SerializeField] private float _minYRotation=0f;
    [SerializeField] public float _maxYRotation=360f;

    [Header("Platform Prefabs")]    
    [SerializeField] private Platform _startPlatformPrefab;
    [SerializeField] private Platform _finishPlatformPrefab;
    [SerializeField] private Platform[] _platformVariantsPrefabs;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        float offsetFromTop = _offsetBetweenPlatforms;
        Platform startPlatform = Create(_startPlatformPrefab,ref offsetFromTop);
        

        

        for (int i = 0; i < _platformVariantCount; i++)
        {
            Platform platform = Create(_platformVariantsPrefabs.Random(),ref offsetFromTop);
        }
        Platform finishPlatform = Create(_finishPlatformPrefab, ref offsetFromTop);
    }

    private Vector3 GetRandomYRotation() => 
        Vector3.up * Random.Range(_minYRotation, _maxYRotation);
    private Platform Create(Platform platformPrefab, ref float offsetFromTop)
    {
        Platform createdPlatform = Instantiate(platformPrefab);
        Transform platformTransform = createdPlatform.transform;
        platformTransform.position = Vector3.down * offsetFromTop;
        platformTransform.eulerAngles = GetRandomYRotation();

        offsetFromTop += createdPlatform.transform.localScale.y + _offsetBetweenPlatforms;

        return createdPlatform;
    }
}
