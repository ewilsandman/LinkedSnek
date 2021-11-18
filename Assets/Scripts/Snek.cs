using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour // The new system is only really grid based for the head of the snake, the rest of the snake relies on its LinkedList
{
    public Hex previousPos;
    public Hex currentHex;
    public GameObject newSnakeSegment;
    
    private Snek _nextSnek;
    private GameObject _instantiatedSegment;

    public void Move(Hex newPosition)
    {
        if (_nextSnek)
        {
            _nextSnek.Move(previousPos);
        }
        else
        {
            currentHex.Snek = false;
        }
        transform.position = newPosition.transform.position;
        currentHex = newPosition;
        currentHex.Snek = true;
        previousPos = newPosition;
    }

    public void Grow(Hex newPosition)
    {
        if (_nextSnek)
        {
            _nextSnek.Grow(previousPos);
        }
        else
        {
            _instantiatedSegment = Instantiate(newSnakeSegment);
            _instantiatedSegment.GetComponent<Snek>().currentHex = currentHex;
            _instantiatedSegment.GetComponent<Snek>().currentHex.Snek = true;
            _instantiatedSegment.transform.position = transform.position;
            _nextSnek = _instantiatedSegment.GetComponent<Snek>();
        }
        transform.position = newPosition.transform.position;
        currentHex = newPosition;
        currentHex.Snek = true;
        previousPos = newPosition;
    }
}
