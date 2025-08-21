using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        // Xử lý đầu vào người dùng trong Update()
        HandleMovement();
        HandleJumpInput();
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        // Thực hiện các tính toán vật lý trong FixedUpdate()
        CheckIsGrounded();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        // SỬA: Sử dụng rb.velocity để điều khiển di chuyển
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Lật nhân vật theo hướng di chuyển
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void HandleJumpInput()
    {
        // Kiểm tra đầu vào nhảy và trạng thái chạm đất
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioManager.PlayJumpSound(); // Phát âm thanh nhảy
            // SỬA: Sử dụng rb.velocity để thêm lực nhảy
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void CheckIsGrounded()
    {
        // Kiểm tra xem nhân vật có chạm đất không
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với kẻ thù (sử dụng Tag)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Gọi phương thức Game Over từ GameManager
            if (gameManager != null)
            {
                gameManager.GameOver(); // Giả sử GameManager có phương thức này
            }
        }
    }
}