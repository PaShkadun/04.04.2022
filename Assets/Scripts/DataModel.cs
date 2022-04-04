using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataModel
{
    public int cubes;
    public int spheres;

    public List<string> cubesNames = new List<string>();
    public List<string> spheresNames = new List<string>();
    public List<string> bombsNames = new List<string>();

    public int health;
    public int level;
    public int score;

    public Vector3 playerPosition;
    public Quaternion playerRotation;
}