using UnityEngine;

// Điều khiển chuyển động và xoay của người chơi.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Tốc độ di chuyển của người chơi.
    public float rotationSpeed = 120.0f; // Tốc độ xoay của người chơi.

    private Rigidbody rb; // Tham chiếu đến thành phần Rigidbody của người chơi.

    public float jumpForce = 5.0f;

    // Start được gọi một lần trước khi khung hình đầu tiên chạy.
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Truy cập thành phần Rigidbody của người chơi.
    }

    // Update được gọi một lần mỗi khung hình.
    void Update()
    {
        // Xữ lý nhảy
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

    }

    // Xử lý chuyển động và xoay dựa trên vật lý.
    private void FixedUpdate()
    {
        // Di chuyển người chơi dựa trên input trục dọc.
        float moveVertical = Input.GetAxis("Vertical"); // Lấy giá trị từ phím điều khiển dọc (W/S hoặc Up/Down).
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement); // Di chuyển vị trí Rigidbody.

        // Xoay người chơi dựa trên input trục ngang.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime; // Lấy giá trị từ phím điều khiển ngang (A/D hoặc Left/Right).
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f); // Tạo phép quay quanh trục Y.
        rb.MoveRotation(rb.rotation * turnRotation); // Áp dụng phép quay cho Rigidbody.
    }
}
