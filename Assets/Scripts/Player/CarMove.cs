using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Transform _centerMass;
    [SerializeField] private LayerMask _maskPlatform;

    private Rigidbody _rigidbody;

    private bool _isGrounded;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        _isGrounded = false;
        RaycastHit hit;

        if(Physics.Raycast(_centerMass.position, -transform.up, out hit, 0.5f, _maskPlatform))
        {
            Debug.Log("YYY SUKA");
            _isGrounded = true;
        }


        if(_isGrounded)
        {
            _rigidbody.velocity =  new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, 5f);
        }
        else
        {
            _rigidbody.AddForce(Vector3.up * -10f * 50f);
        }

    }
}
