using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public InputField sizeField;
    public InputField speedField;
    
    public int size;
    public int maxSize;
    public int minSize;
    
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
   public void StartGame()
    {
        if (sizeField.text.Length != 0 && speedField.text.Length != 0)
        {
            size = Convert.ToInt32(sizeField.text);
            speed = Convert.ToSingle(speedField.text);
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("Main");
        }
    }

   public void ValidateSize()
   {
       if (sizeField.text.Length != 0)
       {
           try
           {
               size = Convert.ToInt32(sizeField.text);
               if (size < minSize)
               {
                   sizeField.text = minSize.ToString(CultureInfo.CurrentCulture);
               }
               else if (size > maxSize)
               {
                   sizeField.text = maxSize.ToString(CultureInfo.CurrentCulture);
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw;
           }
       }
   }      
   public void ValidateSpeed()
   {
       if (speedField.text.Length != 0)
       {
           try
           {
               speed = Convert.ToSingle(speedField.text);
               if (speed < minSpeed)
               {
                   speedField.text = minSpeed.ToString(CultureInfo.CurrentCulture);
               }
               if (speed > maxSpeed)
               {
                   speedField.text = maxSpeed.ToString(CultureInfo.CurrentCulture);
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw;
           }
       }
   }
}
