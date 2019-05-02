using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float timer;
    private bool grounded;
    private bool canMove;
    private Renderer rend;
    public static bool canTime;
    public float speed;
    public float jumpHeight;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        canTime = false;
        canMove = false;
        grounded = true;
        rb.velocity = rb.velocity * 0f;
        timer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (canTime)
        {
            timer += Time.deltaTime;
        }

        if (GateDrop.instance.dropping)
        {
            canMove = true;
        }

        GUIManager.instance.timerText.text = timer.ToString("F2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (grounded && canMove)
        {
            if (rb.velocity.x < speed)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(Camera.main.transform.right * speed);
                }
            }

            if (rb.velocity.x > -speed)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(Camera.main.transform.right * -speed);
                }
            }

            if (rb.velocity.z < speed)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddForce(Camera.main.transform.forward * speed);
                }
            }

            if (rb.velocity.z > -speed)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(Camera.main.transform.forward * -speed);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Big Jump"))
        {
            speed = other.gameObject.GetComponent<BigJump>().newSpeed;
            jumpHeight = other.gameObject.GetComponent<BigJump>().height;
        }

        if(other.gameObject.tag.Equals("Out of bounds"))
        {
            canMove = false;
            GUIManager.instance.dqText.text = "Off Course\nDisqualified";
            StartCoroutine(LoadMain());
        }

        if (other.gameObject.tag.Equals("End"))
        {
            SetCanTime(false);
            canMove = false;
            if(RaceManager.instance.GetRaceType().Contains("Time Trial"))
            {
                GUIManager.instance.dqText.text = "Final Time: " + timer.ToString("F2");
            }
            else
            {
                GUIManager.instance.dqText.text = "Finished: " + (RaceManager.racersFinished + 1);
            }

            if (RaceManager.instance.GetRaceType().Contains("Men"))
            {
                SaveGameData.instance.SaveMenTimes(timer);
            }
            if (RaceManager.instance.GetRaceType().Contains("Women"))
            {
                SaveGameData.instance.SaveWomenTimes(timer);
            }

            SaveGameData.instance.SaveData();

            StartCoroutine(LoadMain());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Big Jump"))
        {
            speed = 45;
            jumpHeight = 9;
        }
    }

    public static void SetCanTime(bool inBool)
    {
        canTime = inBool;
    }

    public Renderer GetRenderer()
    {
        return rend;
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
