using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Moving : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public Rigidbody Ball;
    public Rigidbody Bat;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ball"))
        {
            source.PlayOneShot(clip);
            Ball.velocity = Bat.velocity + (Ball.velocity* -1);
        }
    }

}
