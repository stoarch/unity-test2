using System.Collections;
using UnityEngine;

public class PlayerKinematicJump : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Максимальная высота прыжка
    public float timeToApex = 0.5f; // Время, чтобы достичь вершины прыжка
    private bool isJumping = false; // Проверка, находится ли игрок в прыжке
    public float forwardSpeed = 15.0f;

    void Update()
    {
        // Прыжок при нажатии клавиши пробела и если не в прыжке
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(PerformJump());
        }
    }

    private IEnumerator PerformJump()
    {
        isJumping = true;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + jumpHeight, startPosition.z);

        // Подъем
        while (elapsedTime < timeToApex)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / timeToApex));
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Опускание
        elapsedTime = 0;
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y - jumpHeight, startPosition.z);

        while (elapsedTime < timeToApex)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / timeToApex));
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
    }
}
