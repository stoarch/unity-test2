using System.Collections;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public Transform door; // Ссылка на дверь
    public Vector3 doorOpenPosition; // Конечная позиция двери
    public float doorMoveSpeed = 1.0f; // Скорость движения двери

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверка, является ли объект игроком
        {
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
