using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeekerScript : MonoBehaviour
{
    private Hex _initialHex; // same as current position of Snek
    private Hex _targetHex; // same as food is currently on

    public Snek snekHead;
    public WorldScript world;
    public FoodScript foodSource;

    private Queue<Hex> _pathToTarget = new Queue<Hex>();
  /*private List<Hex> _uncheckedHexes = new List<Hex>(); // very useful lol
    private List<Hex> moveableHexes = new List<Hex>(); */
    private Dictionary<Hex, Hex> cameFrom = new Dictionary<Hex, Hex>();
    private Queue<Hex> frontier = new Queue<Hex>();
    private Hex current;

    //  private int[] _distance;
    //   private Hex[] _previous;
    
    public Queue<Hex> Begin()
    {
        cameFrom.Clear();
        _pathToTarget.Clear();
        _initialHex = snekHead.currentHex;
        _targetHex = foodSource.foodPosition.GetComponent<Hex>(); 
        return Search();
    }
    private Queue<Hex> Search() // Breadth first search with early exit
    {
        frontier.Enqueue(_initialHex);
        
        cameFrom[_initialHex] = null;
        //Dictionary<Hex, float> costpath;
        
        while (frontier.Count != 0)
        {
            current = frontier.Dequeue();

            if (current.gameObject == _targetHex.gameObject)
            {
                break;
            }

            for (int neighbours = 0; neighbours < 6; neighbours++)
            {
                if (cameFrom.ContainsValue(current.connections[neighbours].GetComponent<Hex>())) continue;
                if (!current.connections[neighbours].GetComponent<Hex>().Wall)
                {
                    frontier.Enqueue(current.connections[neighbours].GetComponent<Hex>());
                    cameFrom[current.connections[neighbours].GetComponent<Hex>()] = current;
                }
            }
        }
        current = _targetHex;
        while (current != _initialHex)
        {
            _pathToTarget.Enqueue(current);
            current = cameFrom[current];
            // optional
            //  _pathToTarget.reverse() // optional
        }
        return _pathToTarget;
    }
}
