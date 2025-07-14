using UnityEngine;

public class UIManager : MonoBehaviour
{

    CameraController cameraController;

    public GameObject resetTransformButton;

    public void enableReset()
    {
        resetTransformButton.SetActive(true);
    }

    public void disableReset()
    {
        resetTransformButton.SetActive(false);
    }

    public void OnResetPosition()
    {
        cameraController.ResetTransform();
    }
}
