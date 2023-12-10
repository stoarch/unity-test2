using System.Collections;
using UnityEngine;

public class Infectable : MonoBehaviour
{
    public bool Infected = false;
    public float timeUntilExplosion = 2f; // Время до взрыва после заражения
    public Material infectedMaterial; // Материал для визуализации заражения

    // Метод для вызова заражения
    public void Infect()
    {
        if (!Infected)
        {
            Infected = true;
            StartCoroutine(InitiateExplosionSequence());
            ChangeAppearance(); // Изменение внешнего вида
        }
    }

    // Корутина для взрыва
    private IEnumerator InitiateExplosionSequence()
    {
        yield return new WaitForSeconds(timeUntilExplosion);
        Explode();
    }

    // Изменение визуального представления зараженного объекта
    private void ChangeAppearance()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = infectedMaterial; // Изменяем материал на "зараженный"
        }
    }

    // Метод для взрыва объекта
    private void Explode()
    {
        // Здесь код для взрыва, например, уничтожение объекта и создание эффектов
        Destroy(gameObject);
    }
}
