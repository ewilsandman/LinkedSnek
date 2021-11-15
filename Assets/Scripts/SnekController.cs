using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekController : MonoBehaviour
{
    public WorldScript worldController;
    public FoodScript foodController;
    public GameObject arrow;
    public Camera mainCamera;
    public Snek snekStart;
    public float timeBetweenMoves;

    private GameObject _startPos;
    private int _nextDirection;
    private float _nextMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = worldController.OriginHex;
        snekStart.currentHex = _startPos.GetComponent<Hex>();
        mainCamera.transform.SetParent(snekStart.transform);
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
        arrow.transform.position = snekStart.currentHex.connections[_nextDirection].transform.position;
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
        if (snekStart.currentHex.connections[_nextDirection].GetComponent<Hex>().Food)
        {
            snekStart.Grow(_nextDirection);
            foodController.FoodChange();
        }
        else if (snekStart.currentHex.connections[_nextDirection].CompareTag("Wall"))
        {
            Death();
        }
        else if (snekStart.currentHex.connections[_nextDirection].GetComponent<Hex>().Snek)
        {
            Death();
        }
        else
        {
            snekStart.Move(_nextDirection);
        }
    }
    private void Death()
    {
        
        Debug.Log("you is kil");
    }
}
