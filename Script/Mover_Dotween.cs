using UnityEngine;
using DG.Tweening;

public class Mover_DOTween : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // đơn vị/giây, DOTween dùng thời lượng nên ta quy đổi
    [SerializeField] private float targetX = 50f;
    private Tween _moveTween;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Huỷ tween cũ (nếu có) để tránh chồng tween
            _moveTween?.Kill();

            Vector3 start = transform.position;
            Vector3 target = new Vector3(targetX, start.y, start.z);
            float distance = Mathf.Abs(target.x - start.x);
            float duration = distance / Mathf.Max(0.0001f, speed); // t = s/v

            _moveTween = transform.DOMove(target, duration)
                                  .SetEase(Ease.Linear)
                                  .SetId(this) // có thể Kill theo id
                                  .OnComplete(() => _moveTween = null);
        }
    }
}