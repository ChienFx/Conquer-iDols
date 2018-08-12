using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour {
    public Dropdown dropdown;
    public static SoundController instance;
    public float volume = 0.8f;
  
    public AudioClip[] listBackgroudMusic;
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
    public void playBackgroundMusic()
    {
        if (source.isPlaying)
            source.Stop();
        source.PlayOneShot(listBackgroudMusic[dropdown.value]);
    }
    private void Update()
    {
        if (!source.isPlaying)
        {
            dropdown.value = Random.Range(0, listBackgroudMusic.Length);
            playBackgroundMusic();
        }
    }
    public void OnValueChange(float vol)
    {
        this.volume = vol;
        source.volume = this.volume;
    }
}
