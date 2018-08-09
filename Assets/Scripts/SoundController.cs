using UnityEngine;

public class SoundController : MonoBehaviour {
    public static SoundController instance;
    public float volume = 0.8f;
    public AudioClip adClickButton, adLevelUp, adScoreUp;

    private AudioSource source;
    
    private bool created = false;
    private void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
        if (instance == null)
            instance = this;
        source = this.GetComponent<AudioSource>();
        source.volume = this.volume;
        
    }
    
    public void playSoundButtonClicked()
    {
        source.PlayOneShot(adClickButton, source.volume);
        Debug.Log("Button clicked");
    }

    public void playSoundLevelUp()
    {
        source.PlayOneShot(adLevelUp);
    }
    public void playSoundScorelUp()
    {
        source.PlayOneShot(adScoreUp);
    }
}
