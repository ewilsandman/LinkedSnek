using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScript : MonoBehaviour
{
    public int mapSize;
    
    public GameObject hex;
    public GameObject originHex;

    private GameObject _data;

    // Start is called before the first frame update
    void Awake()
    {
        _data = GameObject.FindWithTag("Data");
        if (_data)
        {
            mapSize = _data.GetComponent<StartMenuScript>().size;
        }
        Initialize();
    }
    void Initialize()
    {
        originHex = Instantiate(hex, transform);
        originHex.transform.position = transform.position;
        originHex.gameObject.GetComponent<GraphScript>().IterationsToDo = mapSize;
        for (int i = 0; i < 6; i++)
        {
            originHex.gameObject.GetComponent<Hex>().Direction = i;
            originHex.gameObject.GetComponent<GraphScript>().IterateStart(mapSize, i);
        }

        int childCount = transform.childCount;
        Debug.Log(childCount);
        for (int i = 0; i <childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.CompareTag("Wall"))
            {}
            else
            {
                child.GetComponent<GraphScript>().Connect();
            }
        }
    }
    public void Death()
    {
        if (_data)
        {
            Destroy(_data.gameObject);
        }
        SceneManager.LoadScene("GameOver");
    }
}
