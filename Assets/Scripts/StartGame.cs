using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startText;

    public bool gameStarted;

    private void Start() 
    {
        StartCoroutine(StartCounter());
    }

    private IEnumerator StartCounter()
    {
        for(int i = 3; i >= 0; i-- )
        {
            _startText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        _startText.enabled = false;
        gameStarted = true;
    }


}
