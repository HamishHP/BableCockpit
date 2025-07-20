using UnityEngine;

public class AsteroidDestroyScript : MonoBehaviour, IGameClickable
{
    public GameObject particles;

    public GameEvent alarmExitEvent;

    private ShipLaserScript shipLaserScript;

    public void OnClicked()
    {
        DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        shipLaserScript.ShootLaser(transform.position);
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

    public void SetShipLaser(ShipLaserScript shipLaser)
    {
        shipLaserScript = shipLaser;
    }
}