using UnityEngine;


public class IntroController : MonoBehaviour {
    
    private void Start() {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        var worldHeight = Camera.main.orthographicSize;
        var worldWidth = worldHeight * Screen.height / Screen.width;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0);
    }

    public void clickExit()
    {
        Application.Quit();
    }
}
