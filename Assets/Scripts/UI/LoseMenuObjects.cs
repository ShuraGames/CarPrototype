using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuObjects : MonoBehaviour
{

    public static LoseMenuObjects instance;

    [SerializeField] private GameObject _losePanel;

    private void Awake() 
    {
        instance = this;    
    }

    public void ShowPanelLose()
    {
        _losePanel.SetActive(true);
    }
}
