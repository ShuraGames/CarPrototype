using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour, IEndGame
{
    public void OnTriggerEndGame()
    {
        Debug.Log("You Finish Level");
    }

    public void OnTriggerLoseObstacle()
    {
        
    }
}
