using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{
    public int previousPos;
    public Hex currentHex;
    public GameObject newSnakeSegment;
    
    private Snek _nextSnek;
    private GameObject _instantiatedSegment;
    

    public void Move(int newDirection)
    {
        if (_nextSnek)
        {
            _nextSnek.Move(previousPos);
        }
        transform.position = currentHex.connections[newDirection].transform.position;
        currentHex.Snek = false;
        currentHex = currentHex.connections[newDirection].GetComponent<Hex>();
        currentHex.Snek = true;
        previousPos = newDirection;
    }

    public void Grow(int newDirection)
    {
        if (_nextSnek)
        {
            _nextSnek.Grow(previousPos);
        }
        else
        {
            _instantiatedSegment = Instantiate(newSnakeSegment);
            _instantiatedSegment.GetComponent<Snek>().currentHex = currentHex;
            _instantiatedSegment.transform.position = transform.position;
            _nextSnek = _instantiatedSegment.GetComponent<Snek>();
        }
        transform.position = currentHex.connections[newDirection].transform.position;
        currentHex = currentHex.connections[newDirection].GetComponent<Hex>();
        previousPos = newDirection;
    }
}
