using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform target;
    
    [SerializeField] private float _currentPositionMultiply;
    [SerializeField] private bool _thisCamera;
    [SerializeField] private LayerMask _maskObstacle;
    
    private Vector3 _position;

    void Start()
    {
        _position = target.InverseTransformPoint(transform.position);
    }

    void FixedUpdate()
    {

        var oldRotation = target.rotation;
        target.rotation = Quaternion.Euler(0, oldRotation.eulerAngles.y, 0);
        var currentPosition = target.TransformPoint(_position);
        target.rotation = oldRotation;
        
        if(_thisCamera)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x * _currentPositionMultiply, currentPosition.y, currentPosition.z), 10f * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x * _currentPositionMultiply, transform.position.y, currentPosition.z), 5f * Time.fixedDeltaTime);
        }
    }
}
