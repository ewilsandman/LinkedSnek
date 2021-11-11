using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    private Snek _nextSnek;
    public Hex currentHex;
    
    private int _snekDirection;
    public int previousPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Move(int newDirection)
    {
        if (_nextSnek)
        {
            _nextSnek.Move(previousPos);
        }
        transform.position = currentHex.connections[newDirection].transform.position;
        currentHex = currentHex.connections[newDirection].GetComponent<Hex>();
        previousPos = newDirection;
    }
}
