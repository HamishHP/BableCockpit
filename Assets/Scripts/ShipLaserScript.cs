using System.Collections;
using UnityEngine;

public class ShipLaserScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform shipPosition;

    public float laserDuration = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, shipPosition.position);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ShootLaser(Vector3 targetPosition)
    {
        StopAllCoroutines();
        lineRenderer.enabled = true;
        StartCoroutine(ShootLaserTime(targetPosition));
    }

    private IEnumerator ShootLaserTime(Vector3 target)
    {
        lineRenderer.SetPosition(1, target);
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
}