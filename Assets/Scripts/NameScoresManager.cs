using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class NameScoresManager : MonoBehaviour
{
    public static NameScoresManager Instance;
    public string inputName;
    public int scores;
    public string highestinputName;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    class SaveData
    {
        public string inputName;
    }
    class SaveData1
    {
        public int scores;
    }
    class SaveData2
    {
        public string highestinputName;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
       
        data.inputName = GameObject.Find("InputName").GetComponent<TMPro.TMP_InputField>().text;
       
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            inputName = data.inputName;
        }
    }
    public void SaveScores(int m_Points)
    {
        SaveData1 data = new SaveData1();

        data.scores = m_Points;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData1 data = JsonUtility.FromJson<SaveData1>(json);

            scores = data.scores;
        }
    }
    public void SaveHName()
    {
        SaveData2 data = new SaveData2();

        data.highestinputName = inputName;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }

    public void LoadHName()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData2 data = JsonUtility.FromJson<SaveData2>(json);

            highestinputName = data.highestinputName;
        }
    }
}
