//tutorial from here: https://www.youtube.com/watch?v=VJjD1Tp1I8U

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerFollow;
    public float cameraDistance = 30.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerFollow.position.x, playerFollow.position.y, transform.position.z);
    }
}
