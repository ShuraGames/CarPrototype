using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Transform _centerMass;

    private Rigidbody _rigidbody;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {

        _rigidbody.velocity =  new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, 5f);
    }

}
