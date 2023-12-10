using UnityEngine;

public class PlayerHop : MonoBehaviour
{
    public float hopHeight = 3f; // ������ ������
    public float moveSpeed = 5f; // �������� �������� ������
    public float hopRate = 1f; // ��� ����� ��� ����� ������� (� ��������)
    private float nextHopTime; // ����� ���������� ������

    private Rigidbody rb; // Rigidbody ����-������
    private bool isGrounded; // ��������� �� ��� �� �����
    private Vector3 originalPosition; // �������� ������� ��� ������

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    void Update()
    {
        // �������� �� ����� �� ��� � ������ �� ����� ��� ���������� ������
        if (isGrounded && Time.time >= nextHopTime)
        {
            originalPosition = transform.position;
            isGrounded = false;
            nextHopTime = Time.time + hopRate;
        }

        if (!isGrounded)
        {
            // ���������� ������
            Hop();
        }
        else
        {
            // �������� ������
            MoveForward();
        }
    }

    void Hop()
    {
        // ������ � ����� ������� ���� � ������ �� �������� �������
        Vector3 newPosition = originalPosition + Vector3.up * hopHeight + moveSpeed * Time.fixedDeltaTime * transform.forward;
        rb.MovePosition(newPosition);

        // �������� ������ �� ��� ���� ������
        if (transform.position.y >= originalPosition.y + hopHeight)
        {
            isGrounded = true; // ��� ������ ���� � ������ ����� ������ �������
        }
    }

    void MoveForward()
    {
        Vector3 forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        // �������� ������������ � ������
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ��� ����� �� �����
        }
    }
}
