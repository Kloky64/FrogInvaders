using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score;
    private TextMeshProUGUI _text;

    private int GetScore()
    {
        return _score;
    }
    
    public void UpdateScore()
    {
        _score += 100;
    }
    
    void Start()
    {
        _score = 0;
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Assert(_text != null);
        _text.text = "Score: 0";
    }
    
    void Update()
    {
        _text.text = "Score: " + GetScore().ToString();
    }
}
