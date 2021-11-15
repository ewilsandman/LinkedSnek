using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void ScoreChange(int scoreMod)
    {
        score += scoreMod;
    }
}
