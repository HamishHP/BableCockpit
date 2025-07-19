using UnityEngine;

public class AsteroidDestroyScript : MonoBehaviour, IGameClickable
{
    public GameObject particles;

    public void OnClicked()
    {
        DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}