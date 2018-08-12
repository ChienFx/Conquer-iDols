using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
	public GameObject coundownPanel;
	public Text countdownText;
	public static CountDown instance;
	
	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	public void startCountdown(int secs)
    {
        Time.timeScale = 0f;
        StartCoroutine(CountingDown(secs));
    }

    IEnumerator CountingDown(int secs)
    {
        coundownPanel.SetActive(true);
        while (true)
        {
            countdownText.text = secs.ToString();
            if (secs < 0)
            {
                coundownPanel.SetActive(false);
                Time.timeScale = 1f;
                yield break;
            }
            else
            {
                secs--;
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }
}
