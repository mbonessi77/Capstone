using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Text dqText;
    public Text timerText;

    public static GUIManager instance;

    void Awake()
    {
        instance = this;
        dqText.text = "";
    }
}
