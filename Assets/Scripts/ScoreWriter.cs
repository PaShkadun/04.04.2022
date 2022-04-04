using UnityEngine;
using UnityEngine.UI;

public class ScoreWriter : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text level;
    [SerializeField] private Text health;
    [SerializeField] private Text cubes;
    [SerializeField] private Text spheres;

    private InventoryModel _inventoryModel;
    private PersonModel _personModel;

    private string _score = "Score: {0}";
    private string _level = "Level: {0}";
    private string _health = "Health: {0}";
    private string _cubes = "Cubes: {0}";
    private string _spheres = "Spheres: {0}";
    
    private void Start()
    {
        _inventoryModel = Singlentons.GetInventoryModel();
        _personModel = Singlentons.GetPersonModel();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = string.Format(_score, _personModel.Score);
        level.text = string.Format(_level, _personModel.Level);
        health.text = string.Format(_health, _personModel.Health);
        cubes.text = string.Format(_cubes, _inventoryModel.Cubes);
        spheres.text = string.Format(_spheres, _inventoryModel.Spheres);
    }
}
