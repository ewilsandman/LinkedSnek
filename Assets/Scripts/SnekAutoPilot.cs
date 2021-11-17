using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekAutoPilot : MonoBehaviour
{
    public SeekerScript seeker;
    private Queue<Hex> _returnPath;
    private void Update()
    {
        _returnPath = seeker.Begin();
        Debug.Log(_returnPath.Count);
    }
}

