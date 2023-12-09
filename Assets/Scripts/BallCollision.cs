using UnityEngine;

public class BallCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            // ����� ����� �������� ������ ������� �� ������������,
            // ��������, ��������� ������ ���� ��� ���������� �����������.
            Destroy(collision.gameObject); // ���������� �����������
            // ���� ����� ��������� ������ ����, �� ������ ������ ��� ���:
            // transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f); // ���������� �� 10%
        }
    }
}
