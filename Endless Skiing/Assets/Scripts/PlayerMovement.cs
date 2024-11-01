using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 4;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1;

    public float speedIncreasePerPoint = 0.1f;
    public float jumpForce = 5f; // Thêm lực nhảy

    private bool isGrounded; // Kiểm tra nhân vật đang ở trên mặt đất

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Kiểm tra nếu nhân vật đang ở trên mặt đất và nhấn phím nhảy (mặc định là phím "Space")
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(isGrounded);
            Debug.Log("Jump");
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Nhân vật đang ở trên không sau khi nhảy
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu nhân vật chạm vào mặt đất
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is grounded.");
            isGrounded = true;
        }
        else
        { isGrounded = false;
            Debug.Log("Player is not grounded.");
        } 
    }

    public void Die()
    {
        alive = false;
        // Restart the game
        //Invoke("Restart", 2);
        GameManager.inst.CheckAndSaveHighScore();
        Invoke("LoadGameEndScene", 1); // Chuyển sang GameEndScene sau 2 giây
    }

    void LoadGameEndScene()
    {
        SceneManager.LoadScene("GameEndScene");
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}