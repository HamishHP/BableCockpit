using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
    private CircleCollider2D spawnCol;
    public Transform shipPos;
    public GameObject spawnObject;
    public float spawnFrequency = 4f;
    private float spawnTimer = 0;
    public ShipLaserScript shipLaser;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        spawnCol = GetComponent<CircleCollider2D>();

        SpawnAsteroid();
    }

    // Update is called once per frame
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnFrequency)
        {
            spawnTimer = 0;
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        float spawnAngle = Random.Range(0, 360);
        Vector3 spawnPos = new Vector3(Mathf.Sin(spawnAngle), Mathf.Cos(spawnAngle), 0).normalized;
        spawnPos *= spawnCol.radius;
        spawnPos.x += spawnCol.transform.position.x;
        spawnPos.y += spawnCol.transform.position.y;
        spawnPos.z = spawnCol.transform.position.z;

        GameObject spawnedObject = Instantiate(spawnObject, spawnPos, Quaternion.identity);
        AsteroidMoveScript spawnedAsteroid = spawnedObject.GetComponent<AsteroidMoveScript>();
        AsteroidDestroyScript asteroidDestroyScript = spawnedAsteroid.GetComponent<AsteroidDestroyScript>();
        asteroidDestroyScript.SetShipLaser(shipLaser);
        spawnedAsteroid.SetTarget(shipPos);
    }
}