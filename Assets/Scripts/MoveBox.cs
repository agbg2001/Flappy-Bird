using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{

    public float speed = 2;
    //Transform myTransform = transform;
    public float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)(Time.time / 4) % 2 == 0){
            speed = -1;
        } else speed = 1;
        transform.Translate(0, 1 * speed * Time.deltaTime, 0);
    }
}
