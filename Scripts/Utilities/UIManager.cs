using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject[] _pauseObjects;
    private GameObject[] _finishObjects;
    private GameObject[] _winObjects;
    private bool _onPause = false;
    private PlayerController _playerController;
    private bool _isAlive = true;

    private void Pause(bool state)
    {
        Time.timeScale = state ? 0 : 1;
        foreach(GameObject gO in _pauseObjects){
            gO.SetActive(state);
        }

        _onPause = state;
    }
    
    private void End(bool state)
    {
        Time.timeScale = state ? 0 : 1;
        foreach(GameObject gO in _finishObjects){
            gO.SetActive(state);
        }
    }
    
    public void Complete(bool state)
    {
        Time.timeScale = state ? 0 : 1;
        foreach(GameObject gO in _winObjects){
            gO.SetActive(state);
        }
    }
    
    void Start()
    {
        _pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        _finishObjects = GameObject.FindGameObjectsWithTag("Game Over Text");
        _winObjects = GameObject.FindGameObjectsWithTag("Victory");
        Pause(false);
        End(false);
        Complete(false);
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        { 
            Pause(!_onPause);
        }

        if (!_isAlive)
        {
            End(true);
        }
    }

    public void SetAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }

    public void PauseControl()
    {
        Pause(!_onPause);
    }
    
    public void LoadLevel(string level){
        SceneManager.LoadScene(level);
    }

}
