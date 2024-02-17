
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    //[SerializeField] float smoothSpeed = 0.25f;

    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
