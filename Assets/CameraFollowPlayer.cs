using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Transform player;
    Vector3 reference = Vector3.zero;
    public float smoothTime = 3f;
    public float VerticalOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y + VerticalOffset, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref reference, smoothTime);
    }
}
