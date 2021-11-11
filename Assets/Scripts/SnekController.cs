using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekController : MonoBehaviour
{
    public GameObject worldController;
    public GameObject arrow;
    public GameObject startOfSnek;
    public float timeBetweenMoves;

    private GameObject _startPos;
    private int _nextDirection;
    private int _nextPosition;
    private Snek _snekStart;
    private float _nextMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = worldController.GetComponent<WorldScript>().OriginHex;
        _snekStart = startOfSnek.GetComponent<Snek>();
        _snekStart.currentHex = _startPos.GetComponent<Hex>();
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
        arrow.transform.position = _snekStart.GetComponent<Snek>().currentHex.connections[_nextDirection].transform.position;
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
        _snekStart.GetComponent<Snek>().Move(_nextDirection);
    }
}
