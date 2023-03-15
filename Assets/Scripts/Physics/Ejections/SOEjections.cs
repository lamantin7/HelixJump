
using UnityEngine;

[CreateAssetMenu(fileName ="Ejection", menuName ="ScriptableObjects/Physics/Ejection", order=0)]

public class SOEjections : ScriptableObject
{
    [SerializeField] [Min(0.0f)] private float _horizontalPlaneForce;
    [SerializeField]  private float _upwardsModifier;


    public void PushOut(Rigidbody rigidbody, Vector3 position)
    {
        Vector3 forceDirection = (position - rigidbody.worldCenterOfMass).normalized;
        Vector3 force = ScaleForce(forceDirection);
        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }

    private Vector3 ScaleForce(Vector3 forceDirection) =>
        Vector3.Scale(forceDirection, new Vector3
        {
            x = _horizontalPlaneForce,
            y = 1,
            z = _horizontalPlaneForce
        })
        + Vector3.up * _upwardsModifier;
}
