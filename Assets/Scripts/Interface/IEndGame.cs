using UnityEngine;

public interface IEndGame
{
    void OnTriggerEndGame(GameObject player);
    void OnTriggerLoseObstacle(GameObject player);
}
