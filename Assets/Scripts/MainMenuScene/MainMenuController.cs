using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private GameObject playButton, exitButton;

    public void clickPlayButton(){
        SceneManager.LoadScene("Gameplay");
    }
    public void clickExitButton(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Application.Quit();
    }
}
