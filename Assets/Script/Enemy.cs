using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 2f; // Tốc độ di chuyển của kẻ địch
    [SerializeField] private float distance = 5f; // di chuyển của kẻ địch
    private Vector3 startPosition; // Vị trí bắt đầu của kẻ địch
    private bool movingRight = true; // Vị trí mục tiêu mà kẻ địch sẽ di chuyển đến
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // Lưu vị trí bắt đầu của kẻ địch
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPosition.x - distance; // Tính toán biên trái
        float rightBound = startPosition.x + distance; // Tính toán biên phải
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Di chuyển sang phải
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // Di chuyển sang trái
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }

        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale; // Lấy kích thước hiện tại của kẻ địch
        scale.x *= -1; // Đảo ngược trục x
        transform.localScale = scale; // Cập nhật kích thước của kẻ địch
    }    
}
