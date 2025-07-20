using UnityEngine;

public class GameClickScript : MonoBehaviour
{
    private Camera m_Camera;
    public Camera gameCam;
    public RectTransform gameScreen;

    public LayerMask ignoreRays;

    public bool canClick = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            CastClickRay();
        }
    }

    //Returns the position in the game based on where the mouse is placed on the game's screen
    private Vector3 GetMousePos()
    {
        Vector2 newMousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(gameScreen, Input.mousePosition, m_Camera, out newMousePos))
        {
            newMousePos = new Vector2(Mathf.Clamp((newMousePos.x + (gameScreen.rect.width / 2)) / gameScreen.rect.width, 0, 1), Mathf.Clamp((newMousePos.y + (gameScreen.rect.height / 2)) / gameScreen.rect.height, 0, 1));
            Vector3 gameMousePos = gameCam.ViewportToWorldPoint(newMousePos);
            gameMousePos = new Vector3(gameMousePos.x, gameMousePos.y, gameScreen.position.z);
            return gameMousePos;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void CastClickRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetMousePos(), Vector2.zero, 0, ignoreRays);

        if (hit)
        {
            hit.transform.SendMessage("OnClicked", SendMessageOptions.DontRequireReceiver);
        }
    }
}