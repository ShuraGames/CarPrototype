using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailAdd : MonoBehaviour, ITriggerPlayer
{
    [SerializeField] private SimpleCamera _simpleCamera;


    public void OnTriggerCarDetail(GameObject nextPart, GameObject player)
    {
        _simpleCamera.target = nextPart.transform;

        if(nextPart != null)
        {
            DetailCounter.instance.DetailAdd();
            nextPart.transform.position = player.transform.position;
            nextPart.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            Debug.Log("Fucking PRO");
        }
        gameObject.SetActive(false);
    }

    public void OnTriggerObstacle(GameObject previousPart, GameObject player)
    {}
}
