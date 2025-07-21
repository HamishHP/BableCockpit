using System.Collections;
using UnityEngine;

public class ShipLaserScript : MonoBehaviour
{
    public Transform parentObj;
    private LineRenderer lineRenderer;
    public Transform shipPosition;

    public float laserDuration = 0.3f;

    public GameSound laserSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, parentObj.InverseTransformPoint(shipPosition.position));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ShootLaser(Vector3 targetPosition)
    {
        StopAllCoroutines();
        SoundManagerScript.instance.PlaySoundClip(laserSound);
        lineRenderer.enabled = true;
        StartCoroutine(ShootLaserTime(targetPosition));
    }

    private IEnumerator ShootLaserTime(Vector3 target)
    {
        lineRenderer.SetPosition(1, parentObj.InverseTransformPoint(target));
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
}