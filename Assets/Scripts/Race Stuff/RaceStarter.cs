using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStarter : MonoBehaviour
{
    [SerializeField] private new AudioSource audio;
    [SerializeField] private AudioClip cadence;
    [SerializeField] private AudioClip beeps;
    [SerializeField] private AudioClip music;
    [SerializeField] private GateDrop gate;
    [SerializeField] private GameObject player;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject[] players;
    private GameObject temp;

	public GameObject[] ai;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HandleAIPoitions();
    }

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = cadence;
        audio.Play();
        StartCoroutine(RandomStart());
    }

    void HandleAIPoitions()
    {
        players[RaceManager.instance.GetPlayerStart()].SetActive(true);
        temp = players[RaceManager.instance.GetPlayerStart()];
        temp.GetComponent<PlayerController>().GetRenderer().material = materials[RaceManager.instance.GetCountry()];
        

		if (RaceManager.instance.GetRaceType().Equals("Men") || RaceManager.instance.GetRaceType().Equals("Women"))
        {
			Destroy(ai[RaceManager.instance.GetPlayerStart()]);
			Debug.Log ("Destroyed AI in lane: " + RaceManager.instance.GetPlayerStart ());
        }
    }

    IEnumerator RandomStart()
    {
        yield return new WaitForSeconds(cadence.length);
        yield return new WaitForSeconds(Random.Range(0, 5));
        audio.clip = beeps;
        audio.Play();
        yield return new WaitForSeconds(0.5f);
        gate.dropping = true;
        PlayerController.SetCanTime(true);
        yield return new WaitForSeconds(.93f);
        audio.clip = music;
        audio.Play();
    }
}
