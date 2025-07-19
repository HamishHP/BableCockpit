using UnityEngine;

public class CameraLookPlane : MonoBehaviour
{
    CameraController controller;

    public Transform cameraPosition;

    private void Start()
    {
        controller = FindFirstObjectByType<CameraController>();
    }

    private void OnMouseUpAsButton()
    {
        controller.LookAtConsole(cameraPosition);
    }
}
