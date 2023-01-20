using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpForce = 400f;

    private Rigidbody2D rigidBody = null;
    private bool isFacingRight = true;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 horizontalMove = new Vector3(movementX * Time.deltaTime, 0f, 0f);
        transform.Translate(horizontalMove);

        if (movementX > 0f && !isFacingRight) {
            Flip();
        } else if (movementX < 0f && isFacingRight) {
            Flip();
        }

        if (Input.GetButtonDown("Fire1")) {
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1f;
        transform.localScale = playerScale;
    }
}
