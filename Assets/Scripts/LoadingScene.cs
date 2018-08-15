using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

	public void loadScene(string sceneString)
    {
        StartCoroutine(LoadAsynchronously(sceneString));
    }

    IEnumerator LoadAsynchronously(string sceneString)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneString);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = Mathf.Round(progress * 100) + " % ";
            yield return null;
        }
    }
}
