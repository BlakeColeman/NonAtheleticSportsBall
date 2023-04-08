using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pointer : MonoBehaviour
{
    public Button button1;
    public LineRenderer Line;
    public TMP_Text  textbox;
    public Rigidbody Ball;
    Rigidbody clone;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, transform.position + (transform.up * 15));
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.up);
        Physics.Raycast(ray,out hit);
        
        
        coroutine = NewBall();


        if(hit.collider)
        {
            if(hit.collider.CompareTag("button"))
            {
                button1.Select();
                if(OVRInput.GetUp(OVRInput.Button.One))
                {
                    StartCoroutine(coroutine);
                }
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    IEnumerator NewBall()
    {
        textbox.text = "3";
        yield return new WaitForSeconds(1);
        textbox.text = "2";
        yield return new WaitForSeconds(1);
        textbox.text = "1";
        yield return new WaitForSeconds(1);
        textbox.text = "0";
        clone = Instantiate(Ball, new Vector3(-5,3,-1),Quaternion.identity);
        clone.velocity = new Vector3(7,2,0);
    }
}