using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ITriggerPlayer
{
    public void OnTriggerCarDetail(GameObject nextPart, GameObject player)
    {    }

    public void OnTriggerObstacle(GameObject previousPart, GameObject player)
    {
        if(previousPart != null)
        {
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
