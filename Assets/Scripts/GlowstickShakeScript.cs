using UnityEngine;

public class GlowstickShakeScript : MonoBehaviour
{
    public Light pointLight;

    public Camera m_Camera;

    private bool begunDragging = false;
    private float camDistance = 0;
    private Vector3 glowStickPos;

    private Vector3 initialPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDrag()
    {
        if (!begunDragging)
        {
            begunDragging = true;
            camDistance = (transform.position - m_Camera.transform.position).magnitude;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = camDistance;
        glowStickPos = m_Camera.ScreenToWorldPoint(mousePos);

        transform.position = glowStickPos;
    }

    private void OnMouseUp()
    {
        begunDragging = false;
        transform.position = initialPos;
    }
}