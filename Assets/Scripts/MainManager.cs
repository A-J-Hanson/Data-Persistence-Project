using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    
    public string playerName = "Player";
    public int highScore = 0;
    public string hsName = "Player";

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
        public int highScore;
        public string hsName;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.hsName = hsName;
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
            Debug.Log(Application.persistentDataPath);

            hsName = data.hsName;
            highScore = data.highScore;
            }
    }
}
