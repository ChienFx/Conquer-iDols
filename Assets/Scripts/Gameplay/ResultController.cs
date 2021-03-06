﻿using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

    private int level, score, idolCode;
    private int index = 0;

    public void clickNextButton()
    {
        SoundController.instance.playSoundButtonClicked();
        index = (++index) % level;
    }

    public void clickPrevButton()
    {
        SoundController.instance.playSoundButtonClicked();
        index = (--index + level) % level;//4-- = 3 + 10 = 13 
    }
    void Update () {
        if(GameplayController.instance.resultPanel.active)
        {
            idolCode = GameplayController.instance.idolCode;
            level = GameplayController.instance.level;
            score = GameplayController.instance.score;
	        GameObject.Find("ScoreValue").GetComponent<Text>().text = score.ToString();
            GameObject.Find("LevelValue").GetComponent<Text>().text = level.ToString();
            GameObject.Find("max_index").GetComponent<Text>().text = level.ToString();
            GameObject.Find("current_index").GetComponent<Text>().text = (index+1).ToString();
            GameObject.Find("ImageSlider").GetComponent<Image>().sprite = GameplayController.instance.spriteIdolArr[idolCode * 10 + index];
        }   
	}
}
