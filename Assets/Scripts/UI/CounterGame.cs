using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterGame : MonoBehaviour
{
    public static CounterGame instance;

    [Header("TextMesh")]
    [SerializeField] private TextMeshProUGUI _countDetailText; //Счетчик деталей в процессе игры
    [SerializeField] private TextMeshProUGUI _lastMoneyCount; //Счетчик монет в финальной сцене
    [SerializeField] private TextMeshProUGUI _loseDetailsCount;

    [SerializeField] private int _maxDetailCount; //Максимальное количество деталей на уровне

    private Color _textColor;
    private int _currentNomberDetails = 0;
    private int _changeMoney;

    private void Awake() 
    {
        instance = this;    
    }

    private void Start() 
    {
        GetCountUI(_currentNomberDetails);
        _textColor = _countDetailText.GetComponent<TextMeshProUGUI>().color;
    }

    //Счетчик деталей
    public void RemoveDetail()
    {
        _currentNomberDetails -= 1;
        _changeMoney -= 100;
        GetCountUI(_currentNomberDetails);
    }

    public void DetailAdd()
    {   
        _currentNomberDetails += 1;
        _changeMoney += 100;
        GetCountUI(_currentNomberDetails);
    }

    public void GetLastMoneyCountUI()
    {
        _lastMoneyCount.text = _changeMoney.ToString();
    }

    private void GetCountUI(int current)
    {
        _countDetailText.text = current.ToString() + " / " + _maxDetailCount.ToString();
        _loseDetailsCount.text = current.ToString() + " / " + _maxDetailCount.ToString();;

    }

}
