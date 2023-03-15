
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallBounce _bounce;
    [SerializeField] private BallParticles _particles;
    [SerializeField] private Transform _ball;

    private bool _collided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformObstacle _))
        {
            Destroy();
            return;
        }
        if (_collided)
            return;

        _collided = true;

        _bounce.BounceOff(Vector3.up);
            _particles.EmitSpotParticles(collision);
            _particles.EmitCollisionParticles(collision);
        
            
        
    }
    private void OnCollisionExit(Collision collision)
    {
        _collided=false;
    }

    private void Destroy()
    {
        _particles.EmitDestroyParticles(_ball.position);
        Destroy(_ball.gameObject);
    }


}
