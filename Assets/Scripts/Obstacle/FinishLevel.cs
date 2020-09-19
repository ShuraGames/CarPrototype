using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour, IEndGame
{

    [SerializeField] private Transform _winnerPlatform;

    public void OnTriggerEndGame(GameObject player)
    {

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<CarMove>().enabled = false;
        player.transform.position = new Vector3(_winnerPlatform.position.x, _winnerPlatform.position.y, _winnerPlatform.position.z);
        
    }

    public void OnTriggerLoseObstacle(GameObject player)
    {
        
    }
}
