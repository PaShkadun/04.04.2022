using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private Transform secondLevelPosition;
    [SerializeField] private GameObject character;

    private PersonModel _personModel;

    private void Start()
    {
        _personModel = Singlentons.GetPersonModel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_personModel.Score < 100)
        {
            return;
        }

        var items = Singlentons.GetItemsModel();
        items.Bombs.RemoveAll(x => x);
        items.Cubes.RemoveAll(x => x);
        items.Spheres.RemoveAll(x => x);

        Singlentons.GetGameStatus().IsStarted = false;

        if (_personModel.Level == 1)
        {
            _personModel.Level++;
            SceneManager.LoadScene(1);
        }
        else
        {
            _personModel.Level--;
            SceneManager.LoadScene(0);
        }
    }
}
