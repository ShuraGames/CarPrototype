using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAssembly : MonoBehaviour
{
    [SerializeField] private GameObject _nextPart;
    [SerializeField] private GameObject _previousPart;

    private void OnTriggerEnter(Collider other) 
    {
        ITriggerPlayer trigger = other.GetComponent<ITriggerPlayer>();
        Debug.Log(trigger);
        if(trigger != null)
        {
            trigger.OnTriggerCarDetail(_nextPart, gameObject);
            trigger.OnTriggerObstacle(_previousPart, gameObject);
        }
    }
}
