using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Canvas startMenu;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Canvas score;

    private GameStatusModel _gameStatusModel;
    private GodClass _godClass;

    private void Start()
    {
        _gameStatusModel = Singlentons.GetGameStatus();
        
        startMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_gameStatusModel.IsStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
            return;
        }

        if (!_gameStatusModel.IsStarted && Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }

        if (_gameStatusModel.IsStarted && Input.GetKeyDown(KeyCode.Space))
        {
            _gameStatusModel.IsPaused = !_gameStatusModel.IsPaused;
            pauseMenu.gameObject.SetActive(_gameStatusModel.IsPaused);
            score.gameObject.SetActive(!_gameStatusModel.IsPaused);
        }

        if (_gameStatusModel.IsPaused && Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    public void LoadGame()
    {
        if (_godClass is null)
        {
            _godClass = new GodClass();
        }

        _godClass.Deserialize();

        var level = Singlentons.GetPersonModel().Level;

        if (level != 1)
        {
            SceneManager.LoadScene(level - 1);
        }
        
        _godClass.SetValues();
    }

    public void SaveGame()
    {
        if (_godClass is null)
        {
            _godClass = new GodClass();
        }
            
        _godClass.Serialize();
    }

    public void StartGame()
    {
        _gameStatusModel.IsStarted = true;
        startMenu.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
    }
}