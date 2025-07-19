using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private UIManager uiManager;

    public float moveSpeed;

    private Vector3 resetRotation;
    private Vector3 resetPosition;

    private bool canRotate = true;

    private void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();

        resetRotation = Vector3.zero;
        resetPosition = transform.position;

    }

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //left
                RotateLeft();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //right
                RotateRight();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ResetTransform();
            }
        }

    }

    private void RotateLeft()
    {
        Vector3 currentEuler = transform.eulerAngles;

        // Convert Y to signed value (-180 to 180)
        float currentY = NormalizeAngle(currentEuler.y);

        // Calculate new Y rotation
        float newY = Mathf.Clamp(currentY - 90f, -90f, 90f);

        // Apply new rotation using DOTween
        Vector3 newRotation = new Vector3(currentEuler.x, newY, currentEuler.z);
        transform.DORotate(newRotation, moveSpeed, RotateMode.Fast);
    }

    // Helper method
    private float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }

    private void RotateRight()
    {
        Vector3 currentEuler = transform.eulerAngles;

        // Convert Y to signed value (-180 to 180)
        float currentY = NormalizeAngle(currentEuler.y);

        // Calculate new Y rotation
        float newY = Mathf.Clamp(currentY + 90f, -90f, 90f);

        // Apply new rotation using DOTween
        Vector3 newRotation = new Vector3(currentEuler.x, newY, currentEuler.z);
        transform.DORotate(newRotation, moveSpeed, RotateMode.Fast);
    }

    public void LookAtConsole(Transform lookTransform)
    {
        canRotate = false;
        resetRotation = transform.eulerAngles;
        transform.DOMove(lookTransform.position, moveSpeed);
        transform.DORotate(lookTransform.eulerAngles, moveSpeed, RotateMode.Fast);
        uiManager.enableReset();
    }

    public void ResetTransform()
    {
        canRotate = true;
        transform.DOMove(resetPosition, moveSpeed);
        transform.DORotate(resetRotation, moveSpeed, RotateMode.Fast);
        uiManager.disableReset();
    }
}