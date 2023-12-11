using System.Collections;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform player; // ������ �� ���-������
    public Transform door; // ������ �� �����
    public float triggerDistance = 5.0f; // ���������� ���������
    public float doorMoveSpeed = 1.0f; // �������� �������� �����
    public Vector3 doorOpenPosition; // �������� ������� �����

    private bool doorOpening = false; // ���� ������ �������� �����

    void Update()
    {
        // ������ ���������� ����� ����� � ������
        float distanceToDoor = Vector3.Distance(player.position, door.position);

        // �������� ������� ���������
        if (distanceToDoor <= triggerDistance && !doorOpening)
        {
            doorOpening = true;
            StartCoroutine(MoveDoor(doorOpenPosition));
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        // ������� �������� ����� �� �������� �������
        while (door.position != targetPosition)
        {
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
