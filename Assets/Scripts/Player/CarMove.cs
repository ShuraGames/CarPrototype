using UnityEngine;
using Lean.Touch;

public class CarMove : MonoBehaviour
{
    [SerializeField] private Transform _centerMass;
    [SerializeField] private LayerMask _maskPlatform;

    private Rigidbody _rigidbody;

    private bool _isGrounded;
    private LeanDragTranslate _dragTranslate;


    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.Scale(_centerMass.localPosition, transform.localScale);
        _dragTranslate = GetComponent<LeanDragTranslate>();
    }

    private void FixedUpdate() 
    {
        RotationCar(_dragTranslate._test);

        _isGrounded = false;
        RaycastHit hit;

        if(Physics.Raycast(_centerMass.position, -transform.up, out hit, 0.5f, _maskPlatform))
        {
            _isGrounded = true;
        }

        if(_isGrounded)
        {
            _rigidbody.velocity =  new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, 10f);
        }
    }


    public void RotationCar(Vector3 indexTranslate)
    {




        if(indexTranslate.x > 0f)
        {

            transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, 15f, transform.rotation.z), 50 * Time.fixedDeltaTime);
        }
        if(indexTranslate.x == 0f)
        {

            
           transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z), 50 * Time.fixedDeltaTime);
        }
        if(indexTranslate.x < 0f)
        {

            
           transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, -15f, transform.rotation.z), 50 * Time.fixedDeltaTime);
        }
    }
}
