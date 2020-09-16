using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailCounter : MonoBehaviour
{
    public static DetailCounter instance;


    [SerializeField] private TextMeshProUGUI _countDetailText;
    [SerializeField] private int _maxDetailCount;

    private int _currentNomberDetails = 0;
    private Color _textColor;
    public int CurrentNomberDetails { get => _currentNomberDetails; set => _currentNomberDetails = value; }

    private void Awake() 
    {
        instance = this;    
    }

    private void Start() 
    {
        GetCountUI(_currentNomberDetails);
        _textColor = _countDetailText.GetComponent<TextMeshProUGUI>().color;
    }

    public void RemoveDetail()
    {
        _currentNomberDetails -= 1;
        GetCountUI(_currentNomberDetails);
    }

    public void DetailAdd()
    {   
        _currentNomberDetails += 1;
        GetCountUI(_currentNomberDetails);
    }

    private void GetCountUI(int current)
    {
        _countDetailText.text = current.ToString() + " / " + _maxDetailCount.ToString();
    }
}
