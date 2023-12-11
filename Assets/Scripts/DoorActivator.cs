using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorActivator : MonoBehaviour
{
    public Transform door; 
    public Vector3 doorOpenPosition; 
    public float doorMoveSpeed = 1.0f;
    [SerializeField]
    private UnityEvent OnDoorActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(MoveDoor(doorOpenPosition));
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (door.position != targetPosition)
        {
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorMoveSpeed * Time.deltaTime);
            yield return null;
        }

        OnDoorActivated?.Invoke();
    }
}
