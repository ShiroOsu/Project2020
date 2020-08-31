using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);

        CursorBehaviour();
    }

    private void CursorBehaviour()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}