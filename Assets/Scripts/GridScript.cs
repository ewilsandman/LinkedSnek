using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject hex;
    public GameObject edgeHex;

    public Dictionary<(int, int, int), GameObject> HexGrid; // This is the grid, displays a Hex based on the Cube Grid system
    
    private readonly Vector2 _rOffset = new Vector2(-0.3f, -0.5f); // southwest
    private readonly Vector2 _qOffset = new Vector2(0.6f, 0f); // east
    private readonly Vector2 _sOffset = new Vector2(-0.3f, 0.5f); // northwest


    // New system based on r,q,s "Cube" grid system
    // r + q + s = 0
    public void Generate(int size)
    {
        HexGrid = new Dictionary<(int, int, int), GameObject>();
        for (int q = -size /2; q <= size /2; q++)
        {
            for (int r = -size /2; r <= size /2; r++)
            {
                for (int s = -size /2; s <= size /2; s++)
                {
                    if (q + r + s == 0)
                    {
                        GameObject instance = Instantiate(hex, transform);
                        Vector2 newcoord = _rOffset * r + _qOffset * q + _sOffset * s;
                        instance.transform.Translate(newcoord);
                        instance.GetComponent<Hex>().HexPosition = (q,r,s);
                        HexGrid.Add((q, r, s),instance);
                    }
                }
            }
        }
    }

      public GameObject GridTranslation((int,int,int) position , int direction)
      {
          int q = position.Item1;
          int r = position.Item2;
          int s = position.Item3;
          switch (direction)
          {
              case 0:
                  q += 1;
                  s -= 1;
                  return HexGrid[(q, r, s)];
              case 1:
                  q += 1;
                  r -= 1;
                  return HexGrid[(q, r, s)];
              case 2: 
                  r -= 1;
                  s += 1;
                  return HexGrid[(q, r, s)];
             case 3:
                 q -= 1;
                 s += 1;
                 return HexGrid[(q, r, s)];
             case 4: 
                 q -= 1;
                 r += 1;
                 return HexGrid[(q, r, s)];
             case 5:
                 r += 1;
                 s -= 1;
                 return HexGrid[(q, r, s)]; 
              default: 
                  return null;
        }
    }
    
}
        

