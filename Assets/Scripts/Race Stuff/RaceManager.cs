using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    private GameObject[] ai;
    [SerializeField] private string raceType;

    public int playerStart;
    public int country;

    public static int racersFinished;
    public static RaceManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        racersFinished = 0;
    }

    public void SetGatePosition(int gatePos)
    {
        playerStart = gatePos;
    }

    public int GetPlayerStart()
    {
        return playerStart;
    }

    public void SetRaceType(string type)
    {
        raceType = type;
    }

    public string GetRaceType()
    {
        return raceType;
    }

    public void SetCountry(int index)
    {
        country = index;
    }
    public int GetCountry()
    {
        return country;
    }
}
