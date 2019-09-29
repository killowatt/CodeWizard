using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public float Smoothing = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 t = Player.transform.position;
        t.z = -10;

        Vector3 velocity = Vector3.zero;
        Vector3 desired = Vector3.SmoothDamp(transform.position, t, ref velocity, Smoothing);

        desired *= 16.0f;
        desired.x = Mathf.Round(desired.x);
        desired.y = Mathf.Round(desired.y);
        //desired.z = Mathf.Round(desired.z);
        desired /= 16.0f;

        transform.position = desired;
    }
}
