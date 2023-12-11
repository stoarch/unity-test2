using System.Collections;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform player; // Ссылка на шар-игрока
    public Transform door; // Ссылка на дверь
    public float triggerDistance = 5.0f; // Расстояние активации
    public float doorMoveSpeed = 1.0f; // Скорость движения двери
    public Vector3 doorOpenPosition; // Конечная позиция двери

    private bool doorOpening = false; // Флаг начала открытия двери

    void Update()
    {
        // Расчет расстояния между шаром и дверью
        float distanceToDoor = Vector3.Distance(player.position, door.position);

        // Проверка условия активации
        if (distanceToDoor <= triggerDistance && !doorOpening)
        {
            doorOpening = true;
            StartCoroutine(MoveDoor(doorOpenPosition));
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        // Плавное движение двери до заданной позиции
        while (door.position != targetPosition)
        {
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
