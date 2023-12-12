using System.Collections;
using UnityEngine;

public class PlayerKinematicJump : MonoBehaviour
{

    const float pathWidth = 1.0f;

    public float jumpHeight = 2.0f; 
    public float timeToApex = 0.5f; 
    private bool isJumping = false; 
    public float forwardSpeed = 15.0f;
    [SerializeField]
    private int obstacleLayer;

    void Update()
    {
        if (DetectObstacle() && !isJumping)
        {
            StartCoroutine(PerformJump());
        }
    }

    bool DetectObstacle()
    {
        var playerRadius = transform.localScale.x / 2;
        float adjustedPathWidth = (pathWidth - playerRadius) / 2;

        var leftRayStart = transform.position - transform.right * adjustedPathWidth;
        var rightRayStart = transform.position + transform.right * adjustedPathWidth;

        Debug.DrawRay(leftRayStart, transform.forward * 2, Color.blue);
        Debug.DrawRay(rightRayStart, transform.forward * 2, Color.blue);

        bool leftHit = Physics.Raycast(leftRayStart, transform.forward, 2, obstacleLayer);
        bool rightHit = Physics.Raycast(rightRayStart, transform.forward, 2, obstacleLayer);

        return leftHit || rightHit; 
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green, 2f);
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
            transform.position += forwardSpeed * Time.deltaTime * transform.forward;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
    }
}
