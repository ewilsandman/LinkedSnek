using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject hex;

    public Dictionary<(int, int, int), GameObject> HexGrid; // This is the grid, displays a Hex based on the Cube Grid system

    private readonly Vector2 _rOffset = new Vector2(-0.3f, -0.5f); // southwest
    private readonly Vector2 _qOffset = new Vector2(0.6f, 0f); // east
    private readonly Vector2 _sOffset = new Vector2(-0.3f, 0.5f); // northwest
    private int _mapSize;


    // New system based on r,q,s "Cube" grid system
    // r + q + s = 0
    public void Generate(int size)
    {
        _mapSize = size;
        HexGrid = new Dictionary<(int, int, int), GameObject>();
        for (int q = -size; q <= size; q++)
        {
            for (int r = -size; r <= size; r++)
            {
                for (int s = -size; s <= size; s++)
                {
                    if (q + r + s == 0)
                    {
                        GameObject instance = Instantiate(hex, transform);
                        Vector2 newcoord = _rOffset * r + _qOffset * q + _sOffset * s;
                        instance.transform.Translate(newcoord);
                        instance.name = (q, r, s).ToString();
                        instance.GetComponent<Hex>().HexPosition = (q, r, s);
                        HexGrid.Add((q, r, s), instance);
                    }
                }
            }
        }
    }
    public GameObject GridTranslation((int,int,int) position , int direction) // THIS SYSTEM HAS CAUSED MUCH SUFFERING, HENCE THE VERY DETAILED LOGS
      {
          int q = position.Item1;
          int r = position.Item2;
          int s = position.Item3;
          switch (direction)
          {
              case 0:
                  if (q + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q + 1, -r , -s)];
                  }

                  if (s - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r , -s -1)];
                  }
                  else
                  {
                      s -= 1;
                      q += 1;
                  }

                  return HexGrid[(q, r, s)];
              case 1:
                  if (q + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q +1, -r , -s)];
                  }

                  if (r - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r -1 , -s)];
                  }
                  else
                  {
                      r -= 1;
                      q += 1;
                  }
                  return HexGrid[(q, r, s)];
              case 2:
                  if (r - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r -1, -s)];
                      
                  }

                  if (s + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      Debug.Log("Secondary attempt, Moving to " + -q + -r + -s+2);
                      return HexGrid[(-q, -r , -s+1)];
                  }
                  else
                  {
                      s += 1;
                      r -= 1;
                  }

                  return HexGrid[(q, r, s)];
              case 3:
                  if (q - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q-1, -r , -s)];
                  }

                  if (s + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r , -s+1)];
                  }
                  else
                  {
                      s += 1;
                      q -= 1;
                  }

                  return HexGrid[(q, r, s)];
              case 4:
                  if (q - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q-1, -r , -s)];
                  }
                  else

                  if (r + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r+1 , -s)];
                  }
                  else
                  {
                      r += 1;
                      q -= 1;
                  }

                  return HexGrid[(q, r, s)];
              case 5:
                  if (r + 1 > _mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r+1 , -s)];
                  }

                  if (s - 1 < -_mapSize)
                  {
                      Debug.Log("border detected, Moving from " +q+r+s + " to " + -q + -r + -s + " Direction " + direction);
                      if (HexGrid.ContainsKey((-q, -r, -s)))
                      {
                          return HexGrid[(-q, -r, -s)];
                      }
                      return HexGrid[(-q, -r , -s-1)];
                  }
                  else
                  {
                      s -= 1;
                      r += 1;
                  }

                  return HexGrid[(q, r, s)];
              default:
                  return null;

           /*
            * 

    Keep a list of the center coordinates of your main map (0, 0, 0), and its 6 shifted copies.

    After a move that might take you off the edge of the map, calculate the distance to your destination tile from each of these center points.

    Stop when you find a center point whose distance away is less than or equal to your map radius.

    Subtract this center point from your destination point. Now your destination is correctly expressed as an offset from the center of your original map (0, 0, 0).

            */
          }
      }
}

        

