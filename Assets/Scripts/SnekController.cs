using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekController : MonoBehaviour
{
    public WorldScript worldController;
    public GridScript grid;
    public FoodScript foodController;
    public GameObject arrow;
    public Snek snekStart;
    public ScoreScript scoreKeeper;
    public float timeBetweenMoves;

    private GameObject _startPos;
    private GameObject _data;
    private int _nextDirection;
    private float _nextMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        _data = GameObject.FindWithTag("Data");
        if (_data)
        {
            timeBetweenMoves = _data.GetComponent<StartMenuScript>().speed;
        }
        _startPos = grid.HexGrid[(0,0,0)];
        snekStart.currentHex = _startPos.GetComponent<Hex>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_nextDirection + 1 > 5)
            {
                _nextDirection = 0;
            }
            else
            {
                _nextDirection += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_nextDirection - 1 < 0)
            {
                _nextDirection = 5;
            }
            else
            {
                _nextDirection -= 1;
            }
        }
        arrow.transform.position = grid.GridTranslation(snekStart.currentHex.HexPosition, _nextDirection).transform.position;
        if (_nextMoveTime > timeBetweenMoves)
        {
            Move();
            _nextMoveTime = 0;
        }
        else
        {
            _nextMoveTime += Time.deltaTime;
        }
    }
    private void Move()
    {
        grid.GridTranslation(snekStart.currentHex.HexPosition, _nextDirection);
       // if (snekStart.currentHex.connections[_nextDirection].GetComponent<Hex>().Food)
        {
            scoreKeeper.ScoreChange(10);
            snekStart.Grow(_nextDirection);
            foodController.FoodChange();
        }
       // else if (snekStart.currentHex.connections[_nextDirection].CompareTag("Wall"))
        {
            worldController.Death();
        }
      //  else if (snekStart.currentHex.connections[_nextDirection].GetComponent<Hex>().Snek)
        {
           worldController.Death();
        }
      //  else
        {
            snekStart.Move(_nextDirection);
        }
    }
}
