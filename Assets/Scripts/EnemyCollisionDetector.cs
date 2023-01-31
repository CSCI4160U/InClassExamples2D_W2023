using UnityEngine;
using UnityEngine.UI;

public class EnemyCollisionDetector : MonoBehaviour
{
    [SerializeField] private Slider playerHealthSlider;

    [SerializeField] private float turnDuration = 2f;

    private CharacterController2D controller;

    private float lastTurnTime;
    private float velocityX = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        lastTurnTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - lastTurnTime) > turnDuration) {
            // turn
            velocityX *= -1f;
            lastTurnTime = Time.time;
        }
        controller.Move(velocityX * Time.deltaTime, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerHealthSlider.value -= 20;
            Debug.Log("Ouch!");
        }    
    }
}
