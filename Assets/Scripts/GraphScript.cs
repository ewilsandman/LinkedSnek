using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hex;
    public GameObject edgeHex;
    public int IterationsLeft;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Iterate(int InterationsLeft)
    {
        if (InterationsLeft > 0)
        {
            for (int connections = 0; connections < 7; connections++)
            {
                Transform newHexPos = gameObject.transform.GetChild(connections).transform;
                bool foundPrevious = false;
                for (int i = 0; i <= transform.parent.childCount; i++)
                {
                    if (transform.parent.GetChild(i).transform.position == newHexPos.position)
                    {
                        foundPrevious = true;
                        break;
                    }
                }
                GameObject newHex = Instantiate(hex);
                newHex.gameObject.GetComponent<GraphScript>().IterationsLeft = IterationsLeft -1;
                newHex.transform.position = newHexPos.position;
            }
        }
        else
        {
            /*Where no hexes already exist, Instantiate(edgeHex
             *
             * 
             */
        }
    }
}
