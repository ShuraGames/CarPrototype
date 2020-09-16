using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacle : MonoBehaviour, IEndGame
{
    public void OnTriggerEndGame()
    {}

    public void OnTriggerLoseObstacle()
    {
        Debug.Log("You death");
    }
}
