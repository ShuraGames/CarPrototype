using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CarAction : MonoBehaviour
{
    [SerializeField] private List<GameObject> _carDetails;
    [SerializeField] private List<Transform> _points;
    private Animator _animator;

    private int _progress = 0;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))    
        {
            _animator.SetTrigger(0);
            _carDetails[1].SetActive(true);
            _progress += 1;

            Debug.Log("Click space");
        }


        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(_progress >= 5) return;

            _carDetails[_progress].SetActive(true);
            _progress += 1;
        }
    }

    private IEnumerator FackingSlaves()
    {
        var i = 5000;
        while(i > 0)
        {
            _carDetails[0].transform.localPosition = Vector3.MoveTowards(transform.position, _points[0].localPosition, Time.deltaTime);

            yield return new WaitForSeconds(0.1f);
            i++;
        }

    }

}
