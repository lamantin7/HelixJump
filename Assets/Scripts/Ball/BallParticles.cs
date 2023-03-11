using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticlePrefab;
    private ParticleSystem _collisionParticle;

    private void Start()
    {
        _collisionParticle = Instantiate(_collisionParticlePrefab);
    }

    private void OnCollisionEnter(Collision collision) =>
        EmitCollisionParticles(collision);
       
    
    private void EmitCollisionParticles( Collision other)
    {
        Vector3 collisionPosition = other.contacts[0].point;
        _collisionParticlePrefab.transform.position=collisionPosition;
        _collisionParticle.Play();
    }
}
