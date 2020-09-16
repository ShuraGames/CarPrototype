using UnityEngine;
using Lean.Touch;
using System.Collections;

public class CarMove : MonoBehaviour
{
    [SerializeField] private float _speedPlayer = 10f;
    [SerializeField] private Transform _centerMass;
    [SerializeField] private LayerMask _maskPlatform;
    [SerializeField] private StartGame _gameStart;

    private Rigidbody _rigidbody;

    private bool _isGrounded;
    private bool _isNitro;
    private LeanDragTranslate _dragTranslate;

    public bool gameStarted;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.Scale(_centerMass.localPosition, transform.localScale);
        _dragTranslate = GetComponent<LeanDragTranslate>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isNitro = true;
        }
    }

    private void FixedUpdate() 
    {
        if(_gameStart.gameStarted)
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
                _rigidbody.velocity =  new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speedPlayer);
            }

            if(_isNitro)
            {
                _isNitro = false;
                StartCoroutine(Nitro());
            }
        }
    }


    private IEnumerator Nitro()
    {
        _speedPlayer = 15f;
        yield return new WaitForSeconds(2f);
        _speedPlayer = 10f;
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
