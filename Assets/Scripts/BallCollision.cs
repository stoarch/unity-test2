using UnityEngine;

public class BallCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            // Здесь можно добавить логику реакции на столкновение,
            // например, уменьшить размер шара или уничтожить препятствие.
            Destroy(collision.gameObject); // Уничтожает препятствие
            // Если нужно уменьшить размер шара, вы можете делать это так:
            // transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f); // Уменьшение на 10%
        }
    }
}
