using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public GameObject food;
    public GameObject boardController;

    private GameObject _foodInstance;
    private GameObject _newPosition;
    // Start is called before the first frame update
    void Start()
    {
        _foodInstance = Instantiate(food);
        FoodChange();
    }
    public void FoodChange()
    {
        if (_newPosition)
        {
            _newPosition.GetComponent<Hex>().Food = false;
        }
        _newPosition = boardController.transform.GetChild(Random.Range(0, boardController.transform.childCount)).gameObject;
        if (!_newPosition.CompareTag("Wall") && !_newPosition.GetComponent<Hex>().Snek)
        {
            _foodInstance.transform.position = _newPosition.transform.position;
            _newPosition.GetComponent<Hex>().Food = true; // Cannot create variable NewHex as not all potential objects have a "Hex"
        }
        else
        {
            FoodChange();
        }
    }
}
