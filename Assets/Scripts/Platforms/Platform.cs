using Platforms;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private SOEjections _ejections;
    [SerializeField] private SOPlatformSettings _settings;

    private PlatformPart[] _parts;

    private void Start() => 
        _parts = GetComponentsInChildren<PlatformPart>();

    public void UnhookAllParts()
    {
        foreach (PlatformPart platformPart in _parts)
        {
            platformPart.UnhookByEjection(_ejections, transform.position);
            Destroy(platformPart.gameObject, _settings.DestroyDelayAfterUnhooking);
            
        }
        Destroy(gameObject,_settings.DestroyDelayAfterUnhooking);
    }

}
