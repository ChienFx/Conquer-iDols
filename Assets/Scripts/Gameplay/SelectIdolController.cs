using UnityEngine;

public class SelectIdolController : MonoBehaviour {
    public GameObject[] Outlines;
    public GameObject SelectPanel, Countdowner;
    
    public void playNowClick(){
        GameplayController.instance.updateIdolImage();
        SoundController.instance.playSoundButtonClicked();
        SelectPanel.SetActive(false);
        GameplayController.instance.restartGame();//start game
        //Instantiate(Countdowner, new Vector3(0,0,0), Quaternion.identity);
        Destroy(gameObject);
    }

    public void idolChoose(int idolCode){
        GameplayController.instance.idolCode = idolCode;
    }

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        for (int i = 0; i < Outlines.Length; i++)
            Outlines[i].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (SelectPanel.active)
        {
            Time.timeScale = 0;
            int idolCode = GameplayController.instance.idolCode;
            for (int i = 0; i < Outlines.Length; i++)
                if(i!=idolCode)
                    Outlines[i].SetActive(false);
            Outlines[idolCode].SetActive(true);
        }
        
    }
}
