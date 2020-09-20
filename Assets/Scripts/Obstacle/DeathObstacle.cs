using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacle : MonoBehaviour, IEndGame
{
    [SerializeField] private GameObject _sparksParticle;

    private SimpleCamera _simpleCamera;

    private void Start() 
    {
        _simpleCamera = Camera.main.GetComponent<SimpleCamera>();
    }

    public void OnTriggerEndGame(GameObject player)
    {}

    public void OnTriggerLoseObstacle(GameObject player)
    {
        StartCoroutine(DeathEvent(player));

    }
    private IEnumerator DeathEvent(GameObject player)
    {
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<CarMove>().enabled = false;
        var instanceParticle = Instantiate(_sparksParticle, player.transform.position, Quaternion.identity);
        Destroy(instanceParticle, instanceParticle.GetComponent<ParticleSystem>().main.duration);

        var count = player.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            var obj = player.transform.GetChild(i);

            var rb = obj.gameObject.AddComponent<Rigidbody>();

            rb.AddForceAtPosition(new Vector3(Random.Range(-3, 3), Random.Range(5, 3), Random.Range(-3, 3)), transform.position, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(2f);
        LoseMenuObjects.instance.ShowPanelLose();

    }
}
