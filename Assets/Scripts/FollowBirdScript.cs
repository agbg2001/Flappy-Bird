using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBirdScript : MonoBehaviour
{
    private BirdScript bird;

    // Use this for initialization
    void Start()
    {
        bird = FindObjectOfType<BirdScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the Camera when the Bird moves
        Vector3 pos = transform.position;
        pos.x = bird.transform.position.x;
        transform.position = pos;
    }
}
