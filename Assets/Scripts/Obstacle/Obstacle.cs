using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ITriggerPlayer
{
    [SerializeField] private GameObject _obstacleEffect;
    
    [SerializeField] private SimpleCamera _simpleCamera;
    

    public void OnTriggerCarDetail(GameObject nextPart, GameObject player)
    {    }

    public void OnTriggerObstacle(GameObject previousPart, GameObject player, GameObject detail)
    {
        _simpleCamera.target = previousPart.transform;
        
        if(previousPart != null)
        {
            CounterGame.instance.RemoveDetail();
            var instanceParticle = Instantiate(_obstacleEffect, player.transform.position, Quaternion.identity);
            Destroy(instanceParticle, instanceParticle.GetComponent<ParticleSystem>().main.duration);
            StartCoroutine(DetailExplosion(detail, player));
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

    private IEnumerator DetailExplosion(GameObject detail, GameObject player)
    {
        if(detail)
        {
            detail.transform.position = player.transform.position;
            detail.SetActive(true);
            detail.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(-3, 3), Random.Range(5, 10), Random.Range(3, 10)), transform.position, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(1f);
        detail.transform.position = Vector3.zero;
        detail.SetActive(false);
    }


}
