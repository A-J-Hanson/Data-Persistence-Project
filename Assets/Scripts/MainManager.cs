using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    
    public string playerName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class DataToSave
    {
        public string playerName;
        public int highScore;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            }
    }
}
