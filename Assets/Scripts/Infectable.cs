using System.Collections;
using UnityEngine;

public class Infectable : MonoBehaviour
{
    public bool Infected = false;
    public float timeUntilExplosion = 2f; 
    public Material infectedMaterial; 

    public void Infect()
    {
        if (!Infected)
        {
            Infected = true;
            StartCoroutine(InitiateExplosionSequence());
            ChangeAppearance(); 
        }
    }

    private IEnumerator InitiateExplosionSequence()
    {
        yield return new WaitForSeconds(timeUntilExplosion);
        Explode();
    }

    private void ChangeAppearance()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = infectedMaterial; 
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
