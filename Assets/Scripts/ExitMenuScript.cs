using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenuScript : MonoBehaviour
{
    public Text score;
    private GameObject _data;

    private void Start()
    {
        _data = GameObject.FindWithTag("Score");
        if (_data)
        {
            score.text = "Your score: " + _data.GetComponent<ScoreScript>().score;
        }
        else
        {
            score.text = "Uh oh, something went wrong with your score";
        }
        Destroy(_data.gameObject);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }
    public void Exit()
    {
        Application.Quit(0);
    }
}
