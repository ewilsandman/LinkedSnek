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
        try
        {
            _data = GameObject.FindWithTag("Score");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        if (_data)
        {
            score.text = "Your score: " + _data.GetComponent<ScoreScript>().score;
            Destroy(_data.gameObject);
        }
        else
        {
            score.text = "Uh oh, something went wrong with your score";
        }
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
