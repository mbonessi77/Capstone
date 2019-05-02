using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    public int speed;

    private void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
