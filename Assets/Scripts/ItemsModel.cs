using System.Collections.Generic;
using UnityEngine;

public class ItemsModel
{
    private List<GameObject> _cubes = new List<GameObject>();
    private List<GameObject> _spheres = new List<GameObject>();
    private List<GameObject> _bombs = new List<GameObject>();

    public List<GameObject> Cubes => _cubes;
    public List<GameObject> Spheres => _spheres;
    public List<GameObject> Bombs => _bombs;
}