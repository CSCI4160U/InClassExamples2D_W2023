using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float runSpeed = 40f;

    [SerializeField] private Animator animator = null;

    private CharacterController2D controller = null;

    private float horizontalMove = 0f;
    private bool isJumping = false;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update() {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
            animator.SetTrigger("IsJumping");
        }

        animator.SetFloat("Speed", Mathf.Abs(controller.speed));
    }

    private void FixedUpdate() {
        // movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);

        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("hit an enemy");
    }
}
