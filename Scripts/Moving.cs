using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody Ball;
    public Rigidbody Bat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision collision)
    {
        Ball.velocity = Bat.velocity;
    }

}
