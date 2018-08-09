using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroController : MonoBehaviour {
    [SerializeField]
    private GameObject ContinueBTN;

    private void Start() {
        var worldHeight = Camera.main.orthographicSize;
        var worldWidth = worldHeight * Screen.height / Screen.width;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0);
    }

    public void ContinueButtonClick() {
        SceneManager.LoadScene("MainMenu");
    }
}
