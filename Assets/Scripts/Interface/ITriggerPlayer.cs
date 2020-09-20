using UnityEngine;

public interface ITriggerPlayer
{
    void OnTriggerCarDetail(GameObject nextPart, GameObject player);
    void OnTriggerObstacle(GameObject previousPart, GameObject player, GameObject detail);
}