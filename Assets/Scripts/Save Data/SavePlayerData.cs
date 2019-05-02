using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavePlayerData
{
    public List<float> menTimes;
    public List<float> womenTimes;
    private string fileName;

    public SavePlayerData(string inName)
    {
        fileName = inName;
        menTimes = new List<float>();
        womenTimes = new List<float>();
    }

    public string GetFileName()
    {
        return fileName;
    }
}
