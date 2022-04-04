using System.Linq;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemsModel _itemsModel;
    private PersonModel _personModel;
    private InventoryModel _inventoryModel;

    private const int BombDamage = 10;
    private const int ScoreForCube = 5;
    private const int ScoreForSphere = 10;
    private const int ScoreForBomb = -15;
    
    private void Start()
    {
        _itemsModel = Singlentons.GetItemsModel();
        _personModel = Singlentons.GetPersonModel();
        _inventoryModel = Singlentons.GetInventoryModel();

        if (gameObject.tag == "Bomb")
        {
            _itemsModel.Bombs.Add(gameObject);
        }
        else if (gameObject.tag == "Cube")
        {
            _itemsModel.Cubes.Add(gameObject);
        }
        else if (gameObject.tag == "Sphere")
        {
            _itemsModel.Spheres.Add(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Bomb")
        {
            var item = _itemsModel.Bombs.FirstOrDefault(x => x.name == name);
            item.SetActive(false);
            
            _personModel.Health -= BombDamage;
            _personModel.Score += ScoreForBomb;
        }
        else if (gameObject.tag == "Cube")
        {
            var item = _itemsModel.Cubes.FirstOrDefault(x => x.name == name);
            item.SetActive(false);
            
            _inventoryModel.Cubes++;
            _personModel.Score += ScoreForCube;
        }
        else if (gameObject.tag == "Sphere")
        {
            var item = _itemsModel.Spheres.FirstOrDefault(x => x.name == name);
            item.SetActive(false);

            _inventoryModel.Spheres++;
            _personModel.Score += ScoreForSphere;
        }
    }
}
