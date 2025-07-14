using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour
{
    UIManager uiManager;

    public float moveSpeed;

    Vector3 resetRotation;
    Vector3 resetPosition;


    private void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();

        resetRotation = Vector3.zero;
        resetPosition = transform.position;
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            //left
            RotateLeft();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            //right
            RotateRight();
        }
        
    }

    void RotateLeft()
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
    float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }

    void RotateRight()
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
        resetRotation = transform.eulerAngles;
        transform.DOMove(lookTransform.position, moveSpeed);
        transform.DORotate(lookTransform.eulerAngles, moveSpeed, RotateMode.Fast);
        uiManager.enableReset();
    }

    public void ResetTransform()
    {
        transform.DOMove(resetPosition, moveSpeed);
        transform.DORotate(resetRotation, moveSpeed, RotateMode.Fast);
        uiManager.disableReset();
    }
}
