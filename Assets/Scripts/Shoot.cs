using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public Transform shootPoint; // �����, ������ ����� �������� ����
    public float shootForce = 2f; // ���� ��������
    public float maxChargeTime = 2f; // ������������ ����� �������

    private float chargeTime; // ������� ����� �������

    void Update()
    {
        // ��� ��������� ������ ���� �������� �������
        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
        }

        // ��� ���������� ������ ���� �������
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            chargeTime = 0; // �������� ����� �������
        }
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(shootPoint.position, shootPoint.forward * 10, Color.red, 2f);
    }

    void Fire()
    {
        Debug.Break();

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Calculate the scale of the bullet based on the charge time
        float scaleMultiplier = Mathf.Clamp(chargeTime / maxChargeTime, 0.5f, 1f); // Assuming the scaleMultiplier varies between 0.5 and 1

        bullet.transform.localScale = bulletPrefab.transform.localScale * scaleMultiplier; // Scale the bullet

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Reduce the shootForce to make the bullet move slower
        float appliedForce = shootForce * scaleMultiplier; // Adjust this value as needed
        rb.AddForce(shootPoint.forward * appliedForce, ForceMode.VelocityChange);

        Debug.Log("Bullet Fired with scale: " + scaleMultiplier + " and force: " + appliedForce);
        Debug.Log("Bullet velocity: " + rb.velocity);

    }
}
