using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public GameObject food;
    public GameObject boardController;
    public GameObject foodPosition;
    public SeekerScript foodSearch;

    private GameObject _foodInstance;
    // Start is called before the first frame update
    void Start()
    {
        _foodInstance = Instantiate(food);
        FoodChange();
    }
    public void FoodChange()
    {
        if (foodPosition)
        {
            foodPosition.GetComponent<Hex>().Food = false;
        }
        foodPosition = boardController.transform.GetChild(Random.Range(0, boardController.transform.childCount)).gameObject;
        if (!foodPosition.CompareTag("Wall") && !foodPosition.GetComponent<Hex>().Snek)
        {
            _foodInstance.transform.position = foodPosition.transform.position;
            foodPosition.GetComponent<Hex>().Food = true; // Cannot create variable NewHex as not all potential objects have a "Hex"
        }
        else
        {
            FoodChange();
        }
        foodSearch.Begin();
    }
}
