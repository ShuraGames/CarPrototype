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
        var currentPosition = target.TransformPoint(_position);
        

        if(_thisCamera)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPosition.x * _currentPositionMultiply, currentPosition.y, currentPosition.z), 2f * Time.deltaTime);
            RaycastHit hit;
            if(Physics.Raycast(target.position, transform.position - target.position, out hit, Vector3.Distance(transform.position, target.position), _maskObstacle))
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
