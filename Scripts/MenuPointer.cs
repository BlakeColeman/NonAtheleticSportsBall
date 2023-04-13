using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPointer : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public LineRenderer Line;

    public TMP_Text  textbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, transform.position + (transform.forward * 20));
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.forward);
        Physics.Raycast(ray,out hit);
        
        if(hit.collider)
        {
            if(hit.collider.CompareTag("button1"))
            {
                button1.Select();
                if(OVRInput.GetUp(OVRInput.Button.One))
                {
                    
                    SceneManager.LoadScene("Scenes/Level1",LoadSceneMode.Single);
                    textbox.text = "Loading";
                }
            }
            else if(hit.collider.CompareTag("button2"))
            {
                button2.Select();
                if(OVRInput.GetUp(OVRInput.Button.One))
                {
                    
                    SceneManager.LoadScene("Scenes/Level2",LoadSceneMode.Single);
                    textbox.text = "Loading";
                }
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
