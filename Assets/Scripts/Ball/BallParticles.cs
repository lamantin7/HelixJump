using UnityEngine;

public class BallParticles : MonoBehaviour
{
    private const float SurfaceYOffset = 0.03f;
    [SerializeField] private ParticleSystem _collisionParticlePrefab;
    [SerializeField] private ParticleSystem _spotParticlesPrefab;
    private ParticleSystem _collisionParticles;

    private void Start() => 
        _collisionParticles = Instantiate(_collisionParticlePrefab);

    private void OnCollisionEnter(Collision collision)
    {
        EmitSpotParticles(collision);
        EmitCollisionParticles(collision);
    }

    private void EmitCollisionParticles( Collision other)
    {
        Vector3 collisionPosition = other.contacts[0].point;
        _collisionParticles.transform.position=collisionPosition;
        _collisionParticles.Play();
    }
    private void EmitSpotParticles (Collision collision)
    {
        Vector3 collisionPosition = collision.contacts[0].point+Vector3.up*SurfaceYOffset;

        Instantiate(_spotParticlesPrefab, collisionPosition,Quaternion.identity, collision.transform);
    }
}
