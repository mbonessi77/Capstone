using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStarter : MonoBehaviour
{
    public GameObject player;
    public GameObject ai;
    public GameObject pos;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(ai);
        player.SetActive(true);
    }
}
