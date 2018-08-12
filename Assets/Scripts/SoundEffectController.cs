using UnityEngine;
using UnityEngine.UI;
public class SoundEffectController : MonoBehaviour {

    public static SoundEffectController instance;
    public float volume = 0.8f;
    public AudioClip adClickButton, adLevelUp, adScoreUp, adGameover, adVictory, adBreak;
	
    public Slider volumeSlider;
    private AudioSource source;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        source = this.GetComponent<AudioSource>();
        source.volume = this.volume;
        volumeSlider.value = this.volume;
        source.loop = true;
    }
   
    public void OnValueChange(float vol)
    {
        this.volume = vol;
        source.volume = this.volume;
    }

    public void playSoundButtonClicked()
    {
        source.PlayOneShot(adClickButton);   
    }

    public void playSoundLevelUp()
    {
        source.PlayOneShot(adLevelUp);
    }
    public void playSoundScorelUp()
    {
        source.PlayOneShot(adScoreUp);
    }
    public void playSoundBreak()
    {
        source.PlayOneShot(adBreak);
    }
    public void playSoundGameOver()
    {
        source.PlayOneShot(adGameover);
    }
    public void playSoundVictory()
    {
        source.PlayOneShot(adVictory);
    }
}
