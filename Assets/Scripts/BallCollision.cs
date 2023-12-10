using UnityEngine;

public class BallCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Destroy(collision.gameObject); 
        }
    }
}
