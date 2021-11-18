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
    public GridScript grid;
    public FoodScript foodSource;

    private List<Hex> _currentPath = new List<Hex>();
    private Queue<Hex> _pathToTarget = new Queue<Hex>();
    private Dictionary<Hex, Hex> cameFrom = new Dictionary<Hex, Hex>();
    private Queue<Hex> frontier = new Queue<Hex>();
    private Hex current;

    //  private int[] _distance;
    //   private Hex[] _previous;

    public void Begin()
    {
        if (_currentPath.Count != 0)
        {
            ClearMap();
        }
        cameFrom.Clear();
        _pathToTarget.Clear();
        _initialHex = snekHead.currentHex;
        _targetHex = foodSource.foodPosition.GetComponent<Hex>();
        foreach (Hex hex in Search())
        {
            _currentPath.Add(hex);
            hex.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }
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
                frontier.Clear();
                break;
            }

            for (int neighbours = 0; neighbours < 6; neighbours++)
            {
                if (cameFrom.ContainsKey(grid.GridTranslation(current.HexPosition, neighbours).GetComponent<Hex>())) continue;
                if (!grid.GridTranslation(current.HexPosition, neighbours).GetComponent<Hex>().Wall)
                {
                    frontier.Enqueue(grid.GridTranslation(current.HexPosition, neighbours).GetComponent<Hex>());
                    cameFrom[grid.GridTranslation(current.HexPosition, neighbours).GetComponent<Hex>()] = current;
                }
            }
        }
        current = _targetHex;
        while (current != _initialHex)
        {
            _pathToTarget.Enqueue(current);
            current = cameFrom[current];
        }
        return _pathToTarget;
    }
    private void ClearMap()
    {
        foreach (Hex hex in _currentPath)
        {
            hex.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
