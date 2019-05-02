using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private GateDrop gate;
    private Vector3 target;
    private int radOfSat;
    private int index;
    private int jumpHeight;
    private bool jumping;
    private Renderer rend;
    private int rand;
    private bool grounded;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, materials.Count);
        radOfSat = 2;
        index = 0;
        jumpHeight = 10;
        target = waypoint[index].transform.position;
        rend = GetComponent<Renderer>();
        rend.material = materials[rand];
        canMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveAI();
    }

    void MoveAI()
    {
        target = waypoint[index].transform.position;
        target -= transform.position;
        target.Normalize();
        Debug.DrawRay(transform.position, target, Color.red);
        if (gate.dropping)
        {
            canMove = true;
            rb.AddForce(target * speed);
        }

        if (grounded && canMove)
        {
            if (rb.velocity.x < speed && rb.velocity.x > -speed && rb.velocity.z < speed && rb.velocity.z > -speed)
                rb.AddForce(target * speed);
        }

        if (Vector3.Distance(waypoint[index].transform.position, transform.position) < radOfSat)
        {
            if (index == waypoint.Length - 1)
            {
                canMove = false;
            }
            else
            {
                index++;
            }
        }
        if (jumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            jumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Jump"))
        {
            jumping = true;
        }

        if (other.gameObject.tag.Equals("End"))
        {
            canMove = false;
            RaceManager.racersFinished++;
        }

        if (other.gameObject.tag.Equals("Waypoint"))
        {
            //waypoint[index].gameObject.GetComponent<MeshRenderer>().enabled = true;
            index++;
        }
        
        if(other.gameObject.tag.Equals("Out of bounds"))
        {
            canMove = false;
        }
        
        if(RaceManager.instance.GetRaceType().Contains("Men"))
        {
            if (other.gameObject.tag.Equals("Start Turn"))
            {
                speed = 30;
                rb.velocity = rb.velocity * .75f;
            }
        }
        else
        {
            if (other.gameObject.tag.Equals("Start Turn"))
            {
                speed = 27;
            }
        }
        
        if (other.gameObject.tag.Equals("End Turn"))
        {
            speed = 40;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            grounded = false;
        }
    }
}
