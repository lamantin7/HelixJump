
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField][Min(0f)] private float _rotatioinSpeed;
    private Quaternion _newRotationAngle;

    private void FixedUpdate()
    {
        transform.rotation = CalculatedRotation(_rotatioinSpeed*Time.deltaTime);
    }

    private Quaternion CalculatedRotation(float rotationSpeed) => 
        Quaternion.Slerp(transform.rotation, _newRotationAngle, rotationSpeed);

    public void AddRotate(float xAxis)
    {
        Vector3 newEulerRotationAngles =transform.eulerAngles+Vector3.down * xAxis;
        _newRotationAngle = Quaternion.Euler(newEulerRotationAngles);
        //float angle = -xAxis * _rotatioinSpeed*Time.deltaTime;
        //transform.Rotate(Vector3.up, angle);
    }
}
