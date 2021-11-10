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
        GameObject OriginHex = Instantiate(hex, transform);
        OriginHex.transform.position = transform.position;
        OriginHex.gameObject.GetComponent<GraphScript>().IterationsToDo = mapSize;
        for (int i = 0; i < 6; i++)
        {
            OriginHex.gameObject.GetComponent<Hex>().Direction = i;
            OriginHex.gameObject.GetComponent<GraphScript>().IterateStart(mapSize, i);
        }
    }
}
