using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour, IEndGame
{

    [Header("GameObjects")]
    [SerializeField] private GameObject _blackPanel;
    [SerializeField] private GameObject _lastWinnerMenu;

    [Header("Transform")]
    [SerializeField] private Transform _winnerPlatform;

    [Header("Cameras")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _cameraFromLastAnimation;

    [Header("Scripts")]
    [SerializeField] private CounterGame _counterGame;

    public void OnTriggerEndGame(GameObject player)
    {

        StartCoroutine(LastEventShow(player));
    }

    public void OnTriggerLoseObstacle(GameObject player)
    {}

    private IEnumerator LastEventShow(GameObject player)
    {
        _blackPanel.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _mainCamera.gameObject.SetActive(false);
        _cameraFromLastAnimation.gameObject.SetActive(true);
        _counterGame.GetLastMoneyCountUI();
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<CarMove>().enabled = false;
        player.transform.position = new Vector3(_winnerPlatform.position.x, _winnerPlatform.position.y, _winnerPlatform.position.z);
        _lastWinnerMenu.SetActive(true);
    }
}
