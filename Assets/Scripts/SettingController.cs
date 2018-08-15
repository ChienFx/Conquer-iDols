using UnityEngine;
using UnityEngine.UI;
public class SettingController : MonoBehaviour {
    public Slider playerSpeedSlider;
    public Text playerSpeedText;
    private void Start()
    {
        playerSpeedSlider.value = GameplayController.instance.playerSpeed;
        playerSpeedText.text = "" + playerSpeedSlider.value;
    }
    public void OnChangePlayerSpeed()
    {
        GameplayController.instance.playerSpeed = playerSpeedSlider.value;
        playerSpeedText.text = ""+ playerSpeedSlider.value;
    }
	
}
