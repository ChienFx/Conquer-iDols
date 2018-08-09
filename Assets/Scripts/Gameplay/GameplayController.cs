using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public float playerSpeed, itemSpeed, gameSpeed;
    public int level, score, idolCode;
    public Sprite[] spriteIdolArr;

    public GameObject menuPanel, resultPanel, resumeButton, exitButton, pauseButton, iDolObj;
    private Image idolImg;
    [SerializeField]
    private Text textScore, textLevel, resultTitleText;

    private void Awake() {
        MakeInstance();
        level = 1;
        score = 0;
        idolCode = 0;
        gameSpeed = 1f;//normal
        idolImg = iDolObj.GetComponent<Image>();
    }

    private void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    private void Update() {
        textScore.text = textScore.text;
        textLevel.text = textLevel.text;
        this.idolImg.sprite = spriteIdolArr[(this.idolCode*10+(this.level - 1)%10)];
    }

    

    public void increaseScore()
    {
        this.score++;
        if (this.score % 5 == 0)
        {
            gameSpeed += 0.05f;
            Time.timeScale = this.gameSpeed;
            itemSpeed++;
        }
        this.textScore.text = this.score.ToString();
        if (score % 3 == 0)
            this.levelUp();
        else
            SoundController.instance.playSoundScorelUp();
    }

    public void levelUp() {
        SoundController.instance.playSoundLevelUp();
        this.level++;
        this.playerSpeed+=5;
        this.itemSpeed+=2;
        this.gameSpeed += 0.1f;
        Time.timeScale = this.gameSpeed;
        this.textLevel.text = this.level.ToString();

        if (this.level == 11){
            showVictoryPanel();
        }
    }

    public void restartGame(){
        this.score = 0;
        this.level = 1;
        gameSpeed = 1f;//normal speed
        Time.timeScale = gameSpeed;
        Debug.Log("time scale 1");
    }
    public void showGameoverPanel(){
        this.showPanel(resultPanel, resultTitleText, "Gameover!");
    }

    public void showVictoryPanel(){
        this.showPanel(resultPanel, resultTitleText, "Victory!");
    }

    private void showPanel(GameObject panel, Text textObj, string titleStr){
        Time.timeScale = 0;
        panel.SetActive(true);
        textObj.text = titleStr;
    }

    /*Clicked Button*/
    public void clickPauseButton()
    {
        SoundController.instance.playSoundButtonClicked();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void clickResumeButton()
    {
        SoundController.instance.playSoundButtonClicked();
        menuPanel.SetActive(false);
        Time.timeScale = this.gameSpeed;
    }
    public void clickRestartButton()
    {
        SoundController.instance.playSoundButtonClicked();
        SceneManager.LoadScene("Gameplay");
    }

    public void clickBackMenuButton()
    {
        SoundController.instance.playSoundButtonClicked();
        SceneManager.LoadScene("MainMenu");
    }
    public void clickExitButton()
    {
        SoundController.instance.playSoundButtonClicked();
        Application.Quit();
    }
}
