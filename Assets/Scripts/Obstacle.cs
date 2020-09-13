using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ITriggerPlayer
{
    [SerializeField] private SimpleCamera _simpleCamera;

    public void OnTriggerCarDetail(GameObject nextPart, GameObject player)
    {    }

    public void OnTriggerObstacle(GameObject previousPart, GameObject player)
    {
        _simpleCamera.target = previousPart.transform;

        if(previousPart != null)
        {
            previousPart.transform.position = player.transform.position;
            previousPart.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            Debug.Log("Fucking loser");
        }
        gameObject.SetActive(false);
    }
}
