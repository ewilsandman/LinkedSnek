using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    public int mapSize;
    
    public GameObject hex;
   // public GameObject food;
   // public GameObject blocker; // may not use

    private GameObject _original;
    
    private Hex[,] _hexes;
    public Hex[,] Hexes => _hexes;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    { }

    void Initialize()
    {
        for (int connections = 0; connections < 7; connections++)
        {
            Transform newHexPos = gameObject.transform.GetChild(connections).transform;
            bool foundPrevious = false;
            for (int i = 0; i <= transform.childCount; i++)
            {
                if (transform.GetChild(i).transform.position == newHexPos.position)
                {
                    foundPrevious = true;
                    break;
                }
            }
            GameObject newHex = Instantiate(hex, transform);
            newHex.gameObject.GetComponent<Hex>().Direction = connections;
            newHex.transform.position = newHexPos.position;
            newHex.gameObject.GetComponent<GraphScript>().Iterate(mapSize -1);
        }
    }
}
