using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public InputField sizeField;
    public InputField speedField;

    public int size;
    public float speed;
    // Start is called before the first frame update
   public void StartGame()
    {
        if (sizeField.text != null && speedField.text != null)
        {
            size = Convert.ToInt32(sizeField.text);
            speed = Convert.ToSingle(speedField.text);
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("Main");
        }
    }
}
