using UnityEngine;

public class Mover_Update : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // đơn vị/giây
    [SerializeField] private float targetX = 50f; // toạ độ thế giới tuyệt đối
    private bool isMoving;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) isMoving = true;

        if (!isMoving) return;

        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        if (pos.x >= targetX)
        {
            pos.x = targetX; // clamp để không vượt quá
            isMoving = false;
        }
        transform.position = pos;
    }
}