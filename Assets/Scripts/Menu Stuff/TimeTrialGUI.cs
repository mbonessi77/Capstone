using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialGUI : MonoBehaviour
{
    [SerializeField]
    private Text menText1, menText2, menText3, menText4, menText5;
    [SerializeField]
    private Text womenText1, womenText2, womenText3, womenText4, womenText5;

    void Start()
    {
        menText1.text = menText2.text = menText3.text = menText4.text = menText5.text = "";
        womenText1.text = womenText2.text = womenText3.text = womenText4.text = womenText5.text = "";
        HighScore();
    }

    // Update is called once per frame
    void HighScore()
    {
        if(SaveGameData.instance.playerData.menTimes.Count == 1)
        {
            menText1.text = "1: " + SaveGameData.instance.playerData.menTimes[0];
        }
        if (SaveGameData.instance.playerData.menTimes.Count == 2)
        {
            menText1.text = "1: " + SaveGameData.instance.playerData.menTimes[0];
            menText2.text = "2: " + SaveGameData.instance.playerData.menTimes[1];
        }
        if (SaveGameData.instance.playerData.menTimes.Count == 3)
        {
            menText1.text = "1: " + SaveGameData.instance.playerData.menTimes[0];
            menText2.text = "2: " + SaveGameData.instance.playerData.menTimes[1];
            menText3.text = "3: " + SaveGameData.instance.playerData.menTimes[2];
        }
        if (SaveGameData.instance.playerData.menTimes.Count == 4)
        {
            menText1.text = "1: " + SaveGameData.instance.playerData.menTimes[0];
            menText2.text = "2: " + SaveGameData.instance.playerData.menTimes[1];
            menText3.text = "3: " + SaveGameData.instance.playerData.menTimes[2];
            menText4.text = "4: " + SaveGameData.instance.playerData.menTimes[3];
        }
        if (SaveGameData.instance.playerData.menTimes.Count >= 5)
        {
            menText1.text = "1: " + SaveGameData.instance.playerData.menTimes[0];
            menText2.text = "2: " + SaveGameData.instance.playerData.menTimes[1];
            menText3.text = "3: " + SaveGameData.instance.playerData.menTimes[2];
            menText4.text = "4: " + SaveGameData.instance.playerData.menTimes[3];
            menText5.text = "5: " + SaveGameData.instance.playerData.menTimes[4];
        }

        if (SaveGameData.instance.playerData.womenTimes.Count == 1)
        {
            womenText1.text = "1: " + SaveGameData.instance.playerData.womenTimes[0];
        }
        if (SaveGameData.instance.playerData.womenTimes.Count == 2)
        {
            womenText1.text = "1: " + SaveGameData.instance.playerData.womenTimes[0];
            womenText2.text = "2: " + SaveGameData.instance.playerData.womenTimes[1];
        }
        if (SaveGameData.instance.playerData.womenTimes.Count == 3)
        {
            womenText1.text = "1: " + SaveGameData.instance.playerData.womenTimes[0];
            womenText2.text = "2: " + SaveGameData.instance.playerData.womenTimes[1];
            womenText3.text = "3: " + SaveGameData.instance.playerData.womenTimes[2];
        }
        if (SaveGameData.instance.playerData.womenTimes.Count == 4)
        {
            womenText1.text = "1: " + SaveGameData.instance.playerData.womenTimes[0];
            womenText2.text = "2: " + SaveGameData.instance.playerData.womenTimes[1];
            womenText3.text = "3: " + SaveGameData.instance.playerData.womenTimes[2];
            womenText4.text = "4: " + SaveGameData.instance.playerData.womenTimes[3];
        }
        if (SaveGameData.instance.playerData.womenTimes.Count >= 5)
        {
            womenText1.text = "1: " + SaveGameData.instance.playerData.womenTimes[0];
            womenText2.text = "2: " + SaveGameData.instance.playerData.womenTimes[1];
            womenText3.text = "3: " + SaveGameData.instance.playerData.womenTimes[2];
            womenText4.text = "4: " + SaveGameData.instance.playerData.womenTimes[3];
            womenText5.text = "5: " + SaveGameData.instance.playerData.womenTimes[4];
        }
    }
}
