using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _mesh;

    [Header("Settings")]
    [SerializeField] private BounceData _bounceData;
    [SerializeField] private Vector3Curves _scaleCurves;

    private Bounce _bounce;
    private BounceEffects _bounceEffects;

    private Vector3 _meshImitialScale;
    private void Start()
    {
        _bounce = new Bounce(_rigidbody, _bounceData);
        _bounceEffects = new BounceEffects(_rigidbody, _bounceData, _scaleCurves);
        _meshImitialScale = _mesh.localScale;
    }
    private void FixedUpdate()
    {
        _bounce.ClampHeight();
        _bounceEffects.ApplyUpwardsScaleTo(_mesh, _meshImitialScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        _bounce.BounceOff(Vector3.up);
    }
}
