using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GodClass
{
    private InventoryModel _inventoryModel;
    private ItemsModel _itemsModel;
    private PersonModel _personModel;
    private DataModel _dataModel;

    private GameObject _player;
    
    private const string Path = "PlayerData.json";

    public GodClass()
    {
        _inventoryModel = Singlentons.GetInventoryModel();
        _itemsModel = Singlentons.GetItemsModel();
        _personModel = Singlentons.GetPersonModel();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Serialize()
    {
        _dataModel = new DataModel();

        _dataModel.cubes = _inventoryModel.Cubes;
        _dataModel.spheres = _inventoryModel.Spheres;

        _dataModel.score = _personModel.Score;
        _dataModel.health = _personModel.Health;
        _dataModel.level = _personModel.Level;

        _dataModel.bombsNames = _itemsModel.Bombs.Where(x => x.activeSelf).Select(x => x.name).ToList();
        _dataModel.cubesNames = _itemsModel.Cubes.Where(x => x.activeSelf).Select(x => x.name).ToList();
        _dataModel.spheresNames = _itemsModel.Spheres.Where(x => x.activeSelf).Select(x => x.name).ToList();

        _dataModel.playerPosition = _player.transform.position;
        _dataModel.playerRotation = _player.transform.rotation;

        var json = JsonUtility.ToJson(_dataModel);

        if (!File.Exists(Path))
        {
            File.Create(Path);
        }
        
        Debug.Log(json);

        File.WriteAllText(Path, json);
    }

    public DataModel Deserialize()
    {
        if (!File.Exists(Path))
        {
            return new DataModel();
        }

        var text = File.ReadAllText(Path);
        var data = JsonUtility.FromJson(text, typeof(DataModel)) as DataModel;

        _dataModel = data;
        
        return data;
    }

    public void SetValues()
    {
        _player.transform.position = _dataModel.playerPosition;
        _player.transform.rotation = _dataModel.playerRotation;
        
        _personModel.Health = _dataModel.health;
        _personModel.Level = _dataModel.level;
        _personModel.Score = _dataModel.score;

        _inventoryModel.Cubes = _dataModel.cubes;
        _inventoryModel.Spheres = _dataModel.spheres;

        var bombs = _itemsModel.Bombs.Select(x => x.name).Except(_dataModel.bombsNames).ToList();
        SetActive(bombs, _itemsModel.Bombs);
        var cubes = _itemsModel.Cubes.Select(x => x.name).Except(_dataModel.cubesNames).ToList();
        SetActive(cubes, _itemsModel.Cubes);
        var sphere = _itemsModel.Spheres.Select(x => x.name).Except(_dataModel.spheresNames).ToList();
        SetActive(sphere, _itemsModel.Spheres);
    }

    private void SetActive(List<string> names, List<GameObject> objects)
    {
        foreach (var name in names)
        {
            objects.FirstOrDefault(x => x.name == name)?.SetActive(false);
        }
    }
}