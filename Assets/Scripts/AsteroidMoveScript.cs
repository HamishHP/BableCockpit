using UnityEngine;

public class AsteroidMoveScript : MonoBehaviour
{
    private Transform targetPos;
    public float moveSpeed;

    public GameEvent shipHitEvent, alarmEnteredEvent;

    //alarm eventtriggger item
    //crash event trigger item

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate((targetPos.position - transform.position).normalized * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            Debug.Log("Hit Ship");

            shipHitEvent.TriggerEvent();
            Destroy(gameObject);
        }

        if (collision.CompareTag("Alarm"))
        {
            Debug.Log("Hit alarm");
            alarmEnteredEvent.TriggerEvent();
        }
    }

    public void SetTarget(Transform target)
    {
        targetPos = target;
    }
}