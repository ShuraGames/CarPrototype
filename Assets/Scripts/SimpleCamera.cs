using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _currentPositionMultiply;
    [SerializeField] private bool _thisCamera;
    [SerializeField] private LayerMask _maskObstacle;
    
    private Vector3 _position;

    void Start()
    {
        _position = _target.InverseTransformPoint(transform.position);
    }

    void FixedUpdate()
    {
        var currentPosition = _target.TransformPoint(_position);
        

        if(_thisCamera)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x * _currentPositionMultiply, currentPosition.y, currentPosition.z), 5f * Time.deltaTime);
            RaycastHit hit;
            if(Physics.Raycast(_target.position, transform.position - _target.position, out hit, Vector3.Distance(transform.position, _target.position), _maskObstacle))
            {
                transform.position = hit.point;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x * _currentPositionMultiply, transform.position.y, currentPosition.z), 5f * Time.deltaTime);
        }
    }
}
