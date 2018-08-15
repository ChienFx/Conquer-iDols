using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private GameObject playButton, exitButton;

    public void clickPlayButton(){
        SoundController.instance.playSoundButtonClicked();
        SceneManager.LoadScene("Gameplay");
    }
    public void clickExitButton(){
        SoundController.instance.playSoundButtonClicked();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Application.Quit();
    }
}
