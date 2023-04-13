using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Ball : MonoBehaviour
{

    public TMP_Text scorecard;
    public AudioClip ding, teleport, hit;
    public AudioSource T, P, B;



    private Rigidbody rb;
    private Vector3 plinth = new Vector3(0.6f, 1.1f, 0.1f);
    private int hits = 0;
    private int thrown = 0;
    private int acc = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        B = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //incase its thrown past the plane
        if(transform.position.y < 0)
        {
            Returnball();
        }
        if(thrown > 0)
        {
            acc = (100 * hits) / thrown;
        }

        scorecard.text = "Hit: " + hits + " Thrown: " + thrown + " Accuracy: " + acc + "%";
    }

    public void OnCollisionEnter(Collision collision)
    {

        B.PlayOneShot(hit);
        if (collision.gameObject.CompareTag("return"))
        {
            Returnball();
        }
        if (collision.gameObject.CompareTag("score")) {
            hits++;
           collision.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(0.75f, 1.75f), Random.Range(5.0f, 7.0f));
            T.PlayOneShot(ding);
        }
    }

    public void Returnball()
    {
        thrown++;
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = plinth;
        rb.useGravity = true;
        rb.isKinematic = false;
        P.PlayOneShot(teleport);
    }
}
