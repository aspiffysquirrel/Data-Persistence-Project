using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string playerName;
    public int bestScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
        }
        else
        {
            playerName = "Player";
            bestScore = 0;
        }
    }
}
