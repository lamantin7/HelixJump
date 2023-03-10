
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField][Min(0f)] private float _rotatioinSpeed;

    public void Rotate(float xAxis)
    {
        float angle = -xAxis * _rotatioinSpeed*Time.deltaTime;
        transform.Rotate(Vector3.up, angle);
    }
}
