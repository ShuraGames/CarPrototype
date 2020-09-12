using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWheel : MonoBehaviour
{
    private void FixedUpdate() 
    {

        transform.Rotate(Vector3.forward * 10f * Time.deltaTime);

    }
}
