using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAssembly : MonoBehaviour
{
    [SerializeField] private GameObject _nextPart;
    [SerializeField] private GameObject _previousPart;
    [SerializeField] private GameObject _detail;

    private void OnTriggerEnter(Collider other) 
    {
        ITriggerPlayer trigger = other.GetComponent<ITriggerPlayer>();
        IEndGame triggerEnd = other.GetComponent<IEndGame>();
        if(trigger != null)
        {
            trigger.OnTriggerCarDetail(_nextPart, gameObject);
            trigger.OnTriggerObstacle(_previousPart, gameObject, _detail);
        }

        if(triggerEnd != null)
        {
            triggerEnd.OnTriggerEndGame(gameObject);
            triggerEnd.OnTriggerLoseObstacle(gameObject);
        }
    }
}
