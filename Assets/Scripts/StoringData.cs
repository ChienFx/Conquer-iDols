using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class StoringData : MonoBehaviour
{
    public static StoringData instance;

    private GameData myGameData;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void LoadGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        myGameData = (GameData)formatter.Deserialize(saveFile);

        GameplayController.instance.playerSpeed = myGameData.playerSpeed;
        SoundController.instance.backgroundVolume = myGameData.backgroundMusicVolume;
        SoundController.instance.soundEffectVolume = myGameData.soundEffectSoundVolume;

        saveFile.Close();
    }

    public void SaveGameData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        myGameData.playerSpeed = GameplayController.instance.playerSpeed;
        myGameData.backgroundMusicVolume = SoundController.instance.backgroundVolume;
        myGameData.soundEffectSoundVolume = SoundController.instance.soundEffectVolume;


        formatter.Serialize(saveFile, myGameData);

        saveFile.Close();
    }
}
