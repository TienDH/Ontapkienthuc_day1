using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover_FixedUpdate : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // đơn vị/giây
    [SerializeField] private float targetX = 50f;
    private bool isMoving;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // mượt hơn trên frame render
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) isMoving = true; // đọc input ở Update
    }

    void FixedUpdate()
    {
        if (!isMoving) return;

        var pos = rb.position;
        pos.x += speed * Time.fixedDeltaTime; // dùng fixedDeltaTime trong FixedUpdate
        if (pos.x >= targetX)
        {
            pos.x = targetX;
            isMoving = false;
        }
        rb.MovePosition(pos); // chuẩn vật lý
    }
}