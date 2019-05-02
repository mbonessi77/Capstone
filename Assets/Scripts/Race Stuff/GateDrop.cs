using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDrop : MonoBehaviour
{
    public bool dropping;
    public bool dropped;
    public int dropSpeed;
    public static GateDrop instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
        dropped = false;
        dropping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dropping)
        {
            transform.Rotate(Vector3.right * dropSpeed * Time.deltaTime);
        }

        if (transform.rotation.x >= 0.7372774)
        {
            dropping = false;
            dropped = true;
        }

    }
}
