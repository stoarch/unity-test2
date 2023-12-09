using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float explosionRadius = DEFAULT_RADIUS; 
    public LayerMask obstacleLayer; // Слой, на котором находятся препятствия

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

        Explode();
        Destroy(gameObject); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, obstacleLayer);
        foreach (var hitCollider in hitColliders)
        {
            //if(hitCollider.CompareTag("Hazard"))
            Destroy(hitCollider.gameObject); 
        }

        //FX of explosion
    }
}
