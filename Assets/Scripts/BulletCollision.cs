using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float explosionRadius = DEFAULT_RADIUS; 
    public LayerMask obstacleLayer; 

    const float DEFAULT_RADIUS = 5f;

    private void Start()
    {
        explosionRadius = gameObject.transform.localScale.magnitude * DEFAULT_RADIUS;
        Debug.Log("Explosion radius: " + explosionRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        InfectNearbyObjects();
        Destroy(gameObject); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void InfectNearbyObjects()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Infectable>(out var infectable))
            {
                infectable.Infect(); 
            }
        }
    }
}
