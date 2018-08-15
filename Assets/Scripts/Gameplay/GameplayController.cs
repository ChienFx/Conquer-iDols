using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;
    
    public float playerSpeed, itemSpeed, gameSpeed;
    public int level, score, idolCode;
    public Sprite[] spriteIdolArr;

    public GameObject menuPanel, resultPanel, settingPanel, resumeButton, exitButton, pauseButton, iDolObj, coundownPanel;
    private Image idolImg;
    [SerializeField]
    private Text textScore, textLevel, resultTitleText, countdownText;
    //private GameData myGameData;

    private void Awake() {
        MakeInstance();
        level = 1;
        score = 0;
        idolCode = 0;
        gameSpeed = 1f;//normal
        idolImg = iDolObj.GetComponent<Image>();
       
    }
    private void Start()
    {
        this.LoadGameData();
        Debug.Log("Run Gameplay");
    }
    private void Update(){
		if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            clickPauseButton();
        }
	}
    private void MakeInstance() {
        if (instance == null)
            instance = this;
    }

    public void updateIdolImage()
    {
        textLevel.text = textLevel.text;
        this.idolImg.sprite = spriteIdolArr[(this.idolCode * 10 + (this.level - 1) % 10)];
    }
    public void increaseScore()
    {
        SoundController.instance.playSoundScorelUp();
        this.score++;
        textScore.text = textScore.text;
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
        this.level++;
        this.updateIdolImage();
        SoundController.instance.playSoundLevelUp();
        
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
        SoundController.instance.playSoundBreak();
        SoundController.instance.playSoundGameOver();
        this.showPanel(resultPanel, resultTitleText, "Gameover!");
    }

    public void showVictoryPanel(){
        SoundController.instance.playSoundVictory();
        this.showPanel(resultPanel, resultTitleText, "Victory!");
    }

    private void showPanel(GameObject panel, Text textObj, string titleStr){
        Time.timeScale = 0;
        panel.SetActive(true);
        textObj.text = titleStr;
    }
    public void closeSettingPanel()
    {
        SoundController.instance.playSoundButtonClicked();
        settingPanel.SetActive(false);
    }
    public void showPanel(GameObject panel)
    {
        SoundController.instance.playSoundButtonClicked();
        panel.SetActive(true);
        Time.timeScale = 0f;
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
        CountDown.instance.startCountdown(3);
    }
    public void clickRestartButton()
    {
        SoundController.instance.playSoundButtonClicked();
        this.SaveGameData();
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
        this.SaveGameData();
        Application.Quit();
    }

    //Load and Save
    public void LoadGameData()
    {
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        //GameData myGameData = new GameData();

        //myGameData = (GameData)formatter.Deserialize(saveFile);

        //this.playerSpeed = myGameData.playerSpeed;
        //SoundController.instance.backgroundVolume = myGameData.backgroundMusicVolume;
        //SoundController.instance.soundEffectVolume = myGameData.soundEffectSoundVolume;

        //SoundController.instance.OnValueChangeBackgroundVolume(myGameData.backgroundMusicVolume);
        //SoundController.instance.OnValueChangeSoundEffectVolume(myGameData.soundEffectSoundVolume);

        //saveFile.Close();

        if (PlayerPrefs.HasKey("_keyPlayerSpeed"))
            this.playerSpeed = PlayerPrefs.GetFloat("_keyPlayerSpeed");
        if(PlayerPrefs.HasKey("_keyBackgroundMusicVolume"))
        {
            float bgVol = PlayerPrefs.GetFloat("_keyBackgroundMusicVolume");
            SoundController.instance.backgroundVolume = bgVol;
            SoundController.instance.OnValueChangeBackgroundVolume(bgVol);
        }
        if (PlayerPrefs.HasKey("_keySoundEffectVolume"))
        {
            float seVol = PlayerPrefs.GetFloat("_keySoundEffectVolume");
            SoundController.instance.soundEffectVolume = seVol;
            SoundController.instance.OnValueChangeSoundEffectVolume(seVol);
        }
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetFloat("_keyPlayerSpeed", this.playerSpeed);
        PlayerPrefs.SetFloat("_keyBackgroundMusicVolume", SoundController.instance.backgroundVolume);
        PlayerPrefs.SetFloat("_keySoundEffectVolume", SoundController.instance.soundEffectVolume);
        PlayerPrefs.Save();

        //if (!Directory.Exists("Saves"))
        //    Directory.CreateDirectory("Saves");

        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream saveFile = File.Create("Saves/save.binary");
        //GameData myGameData = new GameData();
        //myGameData.playerSpeed = this.playerSpeed;
        //myGameData.backgroundMusicVolume = SoundController.instance.backgroundVolume;
        //myGameData.soundEffectSoundVolume = SoundController.instance.soundEffectVolume;


        //formatter.Serialize(saveFile, myGameData);

        //saveFile.Close();
    }
}
