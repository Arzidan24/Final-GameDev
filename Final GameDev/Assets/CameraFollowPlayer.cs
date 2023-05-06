using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 4.3f; //if we want to follow the player height while jumping, unused
    public float xOffset = 10f;
    public float zOffset = -15f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, yOffset , zOffset);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);

        
    }
}
