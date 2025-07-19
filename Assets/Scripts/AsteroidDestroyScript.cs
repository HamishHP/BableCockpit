using UnityEngine;

public class AsteroidDestroyScript : MonoBehaviour, IGameClickable
{
    public GameObject particles;

    public GameEvent alarmExitEvent;

    public void OnClicked()
    {
        DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Alarm"))
        {
            alarmExitEvent.TriggerEvent();
            Debug.Log("Asteroid Gone");
        }
    }
}