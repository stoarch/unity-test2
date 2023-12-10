using UnityEngine;

public class PlayerHop : MonoBehaviour
{
    public float hopHeight = 3f; // Высота прыжка
    public float moveSpeed = 5f; // Скорость движения вперед
    public float hopRate = 1f; // Как часто шар будет прыгать (в секундах)
    private float nextHopTime; // Время следующего прыжка

    private Rigidbody rb; // Rigidbody шара-игрока
    private bool isGrounded; // Находится ли шар на земле
    private Vector3 originalPosition; // Исходная позиция для прыжка

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        // Проверка на земле ли шар и прошло ли время для следующего прыжка
        if (isGrounded && Time.time >= nextHopTime)
        {
            originalPosition = transform.position;
            isGrounded = false;
            nextHopTime = Time.time + hopRate;
        }

        if (!isGrounded)
        {
            // Выполнение прыжка
            Hop();
        }
        else
        {
            // Движение вперед
            MoveForward();
        }
    }

    void Hop()
    {
        // Прыжок к новой позиции выше и вперед от исходной позиции
        Vector3 newPosition = originalPosition + Vector3.up * hopHeight + moveSpeed * Time.fixedDeltaTime * transform.forward;
        rb.MovePosition(newPosition);

        // Проверка достиг ли шар пика прыжка
        if (transform.position.y >= originalPosition.y + hopHeight)
        {
            isGrounded = true; // Шар достиг пика и теперь будет падать обратно
        }
    }

    void MoveForward()
    {
        Vector3 forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверка столкновения с землей
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Шар снова на земле
        }
    }
}
