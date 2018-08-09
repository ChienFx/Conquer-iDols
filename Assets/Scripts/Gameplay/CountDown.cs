using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int timeLeft = 3;
    public Sprite[] spriteCountdown;
    private Image imgCountdown;

    private void Awake()
    {
        imgCountdown = this.GetComponent<Image>();
    }
    void Start()
    {
        StartCoroutine("LoseTime");
        //Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        if (timeLeft < 0)
        {
            Destroy(gameObject);
            Time.timeScale = GameplayController.instance.gameSpeed;
            Debug.Log("Call countdown func!");
        }
        else
            imgCountdown.sprite = spriteCountdown[timeLeft];// myText.text = ("" + timeLeft); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (timeLeft>0)
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
        }
    }
}
