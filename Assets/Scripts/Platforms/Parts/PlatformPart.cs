using Extension;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPart : MonoBehaviour
{
    public void UnhookByEjection(SOEjections ejections, Vector3 centerOfPlatform)
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        transform.ClearParent();
        rigidbody.detectCollisions = false;
        ejections.PushOut(rigidbody,centerOfPlatform);
        
        
        
    }
}
