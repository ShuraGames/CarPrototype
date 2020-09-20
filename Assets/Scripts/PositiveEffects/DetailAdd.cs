using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetailAdd : MonoBehaviour, ITriggerPlayer
{
    [SerializeField] private SimpleCamera _simpleCamera;
    [SerializeField] private GameObject _poofEffect;


    public void OnTriggerCarDetail(GameObject nextPart, GameObject player)
    {
        _simpleCamera.target = nextPart.transform;


        Debug.Log(nextPart);
        if(nextPart != null)
        {

            CounterGame.instance.DetailAdd();
            var instanceParticle = Instantiate(_poofEffect, player.transform.position, Quaternion.identity);
            Destroy(instanceParticle, instanceParticle.GetComponent<ParticleSystem>().main.duration);
            nextPart.transform.position = player.transform.position;
            nextPart.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            Debug.Log("Fucking PRO");
        }
        gameObject.SetActive(false);
    }

    public void OnTriggerObstacle(GameObject previousPart, GameObject player, GameObject detail)
    {}
}
