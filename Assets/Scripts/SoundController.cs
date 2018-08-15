using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour {

    public Dropdown dropdown;
    public static SoundController instance;
    public float backgroundVolume = 0.8f;
  
    public AudioClip[] listBackgroudMusic;
    public Slider backgroundSlider;
    public AudioSource backgroundSource;

    //
    public float soundEffectVolume = 0.3f;
    public AudioClip adClickButton, adLevelUp, adScoreUp, adGameover, adVictory, adBreak;

    public Slider soundEffectSlider;
    public AudioSource soundEffectSource;

    //

    private void Awake()
    {
        if (instance == null)
            instance = this;
       
        backgroundSource.volume = this.backgroundVolume;
        backgroundSlider.value = this.backgroundVolume;
        backgroundSource.loop = true;

      
        soundEffectSource.volume = this.soundEffectVolume;
        soundEffectSlider.value = this.soundEffectVolume;
        soundEffectSource.loop = false;

    }
    public void playBackgroundMusic()
    {
        if (backgroundSource.isPlaying)
            backgroundSource.Stop();
        backgroundSource.PlayOneShot(listBackgroudMusic[dropdown.value]);
    }
    private void Update()
    {
        if (!backgroundSource.isPlaying)
        {
            dropdown.value = Random.Range(0, listBackgroudMusic.Length);
            playBackgroundMusic();
        }
    }
    public void OnValueChangeBackgroundVolume(float vol)
    {
        this.backgroundVolume = backgroundSource.volume = backgroundSlider.value = vol;
    }
    public void OnValueChangeBackgroundVolume()
    {
        this.backgroundVolume = backgroundSource.volume = backgroundSlider.value;
    }

    //Sound Effect methods
    public void OnValueChangeSoundEffectVolume(float vol)
    {
        this.soundEffectVolume = soundEffectSource.volume = soundEffectSlider.value = vol;
    }
    public void OnValueChangeSoundEffectVolume()
    {
        this.soundEffectVolume = soundEffectSource.volume = soundEffectSlider.value;
    }

    public void playSoundButtonClicked()
    {
        soundEffectSource.PlayOneShot(adClickButton);
    }

    public void playSoundLevelUp()
    {
        soundEffectSource.PlayOneShot(adLevelUp);
    }
    public void playSoundScorelUp()
    {
        soundEffectSource.PlayOneShot(adScoreUp);
    }
    public void playSoundBreak()
    {
        soundEffectSource.PlayOneShot(adBreak);
    }
    public void playSoundGameOver()
    {
        soundEffectSource.PlayOneShot(adGameover);
    }
    public void playSoundVictory()
    {
        soundEffectSource.PlayOneShot(adVictory);
    }

}
