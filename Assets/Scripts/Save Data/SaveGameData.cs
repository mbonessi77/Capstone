using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGameData : MonoBehaviour
{
    [HideInInspector] public string dataPath;
    public string fileExt;
    [HideInInspector] public SavePlayerData playerData;

    public static SaveGameData instance; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreateSaveObjects();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void CreateSaveObjects()
    {
        playerData = new SavePlayerData("/Player Data");
        dataPath = Application.persistentDataPath + playerData.GetFileName() + fileExt;
        LoadData();
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dataPath);
        bf.Serialize(file, playerData);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(dataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            playerData = (SavePlayerData)bf.Deserialize(file);
            file.Close();
        }
    }

    public void SaveMenTimes(float inTime)
    {
        if(playerData.menTimes.Count == 0)
        {
            playerData.menTimes.Add(inTime);
        }
        else if(playerData.menTimes.Count < 10)
        {
            playerData.menTimes.Add(inTime);
            playerData.menTimes.Sort();
        }
        else
        {
            if(inTime > playerData.menTimes[9])
            {
                playerData.menTimes.Insert(9, inTime);
                playerData.menTimes.Sort();
            }
        }
    }

    public void SaveWomenTimes(float inTime)
    {
        if (playerData.womenTimes.Count == 0)
        {
            playerData.womenTimes.Add(inTime);
        }
        else if (playerData.womenTimes.Count < 10)
        {
            playerData.womenTimes.Add(inTime);
            playerData.womenTimes.Sort();
        }
        else
        {
            if (inTime > playerData.womenTimes[9])
            {
                playerData.womenTimes.Insert(9, inTime);
                playerData.womenTimes.Sort();
            }
        }
    }
}
