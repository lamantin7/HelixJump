
using Structures;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private SOTowerGenerationSettings _towerGenerationSettings;

    [Header("Tower")]
    [SerializeField] private Transform _transformTower;

    private FloatRange RotationRange=> _towerGenerationSettings.RotationRange;



    private void Start() => 
        Generate(_towerGenerationSettings, _transformTower);

    private void Generate(SOTowerGenerationSettings generationSettings, Transform tower)
    {
       List<Platform> spawnedPlatforms = SpawnPlatforms(generationSettings, out float offsetFromTop);
        FitTowerHeight(tower, offsetFromTop);
        spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
    }
    private List<Platform> SpawnPlatforms(SOTowerGenerationSettings generationSettings, out float offsetFromTop) 
    {
        offsetFromTop = generationSettings.OffsetBetweenPlatforms;        
        const sbyte startAndLastPlatform = 2;
        var spawnedPlatforms = new List<Platform>(generationSettings.PlatformVariantCount+startAndLastPlatform);
        Platform startPlatform = Create(generationSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
        spawnedPlatforms.Add(startPlatform);
        for (int i = 0; i < generationSettings.PlatformVariantCount; i++)
        {
            Platform platform = Create(generationSettings.PlatformVariantPrefabs, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(platform);
        }

        Platform finishPlatform = Create(generationSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
        spawnedPlatforms.Add(finishPlatform);
        return spawnedPlatforms;

    }
    private Vector3 GetRandomYRotation() => 
        Vector3.up * _towerGenerationSettings.RotationRange.Random;
    private Platform Create(Platform platformPrefab,FloatRange rotationRange, ref float offsetFromTop)
    {
        Platform createdPlatform = Instantiate(platformPrefab);
        Transform platformTransform = createdPlatform.transform;
        platformTransform.position = Vector3.down * offsetFromTop;
        platformTransform.eulerAngles = GetRandomYRotation();

        offsetFromTop += createdPlatform.transform.localScale.y + _towerGenerationSettings.OffsetBetweenPlatforms;

        return createdPlatform;
    }
    private void FitTowerHeight(Transform tower, float height)
    {
        Vector3 originalSize= tower.localScale;
        float towerHeight = height / 2f;
        tower.localScale = new Vector3(originalSize.x,towerHeight,originalSize.z);
        tower.localPosition -= Vector3.up * towerHeight;
    }
}
