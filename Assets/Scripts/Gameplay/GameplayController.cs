using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public float playerSpeed, itemSpeed, gameSpeed;
    public int level, score, idolCode, count;
    public Sprite[] spriteIdolArr;

    public GameObject menuPanel, resultPanel, settingPanel, resumeButton, exitButton, pauseButton, iDolObj, coundownPanel;
    private Image idolImg;
    [SerializeField]
    private Text textScore, textLevel, resultTitleText, countdownText;

    private void Awake() {
        MakeInstance();
        level = 1;
        score = 0;
		count = 0;
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
        SoundEffectController.instance.playSoundScorelUp();
        this.score++; this.count++;
        if (this.score % 5 == 0)
        {
            gameSpeed += 0.03f;
            itemSpeed += 0.1f;
        }
        this.textScore.text = this.score.ToString();
        if (score % (level*(level+1)*10) == 0)
            this.levelUp();       
    }

    public void levelUp() {
        SoundEffectController.instance.playSoundLevelUp();
        this.level++;
        this.itemSpeed+=0.5f;
        this.gameSpeed += 0.05f;
        this.textLevel.text = this.level.ToString();

        if (this.level == 11){
            showVictoryPanel();
        }
		
    }

    public void restartGame(){
        this.score = 0;
        this.level = 1;
        gameSpeed = 1f;//normal speed
        Time.timeScale = 1f;

    }
    public void showGameoverPanel(){
        SoundEffectController.instance.playSoundBreak();
        SoundEffectController.instance.playSoundGameOver();
        this.showPanel(resultPanel, resultTitleText, "Gameover!");
    }

    public void showVictoryPanel(){
        SoundEffectController.instance.playSoundVictory();
        this.showPanel(resultPanel, resultTitleText, "Victory!");
    }

    private void showPanel(GameObject panel, Text textObj, string titleStr){
        Time.timeScale = 0;
        panel.SetActive(true);
        textObj.text = titleStr;
    }
    public void closeSettingPanel()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        settingPanel.SetActive(false);
    }
    public void showPanel(GameObject panel)
    {
        SoundEffectController.instance.playSoundButtonClicked();
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    /*Clicked Button*/
    public void clickPauseButton()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void clickResumeButton()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        menuPanel.SetActive(false);
        CountDown.instance.startCountdown(3);
        //Time.timeScale = 1;//this.gameSpeed;
    }
    public void clickRestartButton()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        SceneManager.LoadScene("Gameplay");
    }

    public void clickBackMenuButton()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        SceneManager.LoadScene("MainMenu");
    }
    public void clickExitButton()
    {
        SoundEffectController.instance.playSoundButtonClicked();
        Application.Quit();
    }
}
