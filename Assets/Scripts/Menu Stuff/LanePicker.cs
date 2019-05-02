using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanePicker : MonoBehaviour
{
    [SerializeField] private Text laneText;
    [SerializeField] private Text CountryText;
    [SerializeField] private string[] countries;
    [HideInInspector] public int lane;
    [HideInInspector] public int countryIndex;

    void Start()
    {
        lane = 0;
        countryIndex = 0;
        laneText.text = "1";
        CountryText.text = countries[countryIndex];
        RaceManager.instance.SetGatePosition(lane);
        RaceManager.instance.SetCountry(countryIndex);
    }

    void Update()
    {
        laneText.text = (lane + 1).ToString();
        CountryText.text = countries[countryIndex];
    }

    public void Increment()
    {
        lane++;
        if(lane > 7)
        {
            lane = 0;
        }

        RaceManager.instance.SetGatePosition(lane);
    }

    public void Decrement()
    {
        lane--;
        if (lane < 0)
        {
            lane = 7;
        }

        RaceManager.instance.SetGatePosition(lane);
    }

    public void CountryUp()
    {
        countryIndex++;
        if(countryIndex > countries.Length - 1)
        {
            countryIndex = 0;
        }

        RaceManager.instance.SetCountry(countryIndex);
    }

    public void CountryDown()
    {
        countryIndex--;
        if (countryIndex < 0)
        {
            countryIndex = countries.Length - 1;
        }

        RaceManager.instance.SetCountry(countryIndex);
    }
}
