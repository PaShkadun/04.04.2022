using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Material characterMaterial;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 50f;

    private GameStatusModel _gameStatus;

    private void Start()
    {
        _gameStatus = Singlentons.GetGameStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStatus.IsStarted || _gameStatus.IsPaused)
        {
            return;
        }
        
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (vertical != 0 || horizontal != 0)
        {
            characterMaterial.color = Color.red;

            var x = transform.localPosition.x;
            var y = transform.localPosition.y;
            var z = transform.localPosition.z;

            transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);
        }
        else
        {
            characterMaterial.color = Color.white;
        }
    }
}
