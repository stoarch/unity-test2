using System.Collections;
using UnityEngine;

public class PlayerKinematicJump : MonoBehaviour
{
    public float jumpHeight = 2.0f; // ������������ ������ ������
    public float timeToApex = 0.5f; // �����, ����� ������� ������� ������
    private bool isJumping = false; // ��������, ��������� �� ����� � ������
    public float forwardSpeed = 15.0f;

    void Update()
    {
        // ������ ��� ������� ������� ������� � ���� �� � ������
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

        // ������
        while (elapsedTime < timeToApex)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / timeToApex));
            transform.position += transform.forward * forwardSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���������
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
