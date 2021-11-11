using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Hex : MonoBehaviour
 {
        public int Direction;
        public bool Snek;
        public bool Wall;
        public GameObject Thing;
        public GameObject[] connections = new GameObject[6];
 }