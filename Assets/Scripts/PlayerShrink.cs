using UnityEngine;
using UnityEngine.Events;

public class PlayerShrink : MonoBehaviour
{
    [SerializeField]
    private float minimumSize = 0.1f; 
    [SerializeField]
    private UnityEvent OnGameOver;

    void Update()
    {
        if (transform.localScale.x <= minimumSize)
        {
            GameOver(); 
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        OnGameOver?.Invoke();
    }
}
