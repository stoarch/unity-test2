using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; 
    private Rigidbody rb; 
    private Vector3 nextObstaclePosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            JumpTowardsNextObstacle();
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }

    public void SetNextObstaclePosition(Vector3 position)
    {
        nextObstaclePosition = position;
    }

    private void JumpTowardsNextObstacle()
    {
        Vector3 direction = (nextObstaclePosition - transform.position).normalized;
        rb.AddForce(direction * jumpForce + Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}
