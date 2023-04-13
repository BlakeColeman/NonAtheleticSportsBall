using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DestroyBlock : MonoBehaviour
{
    public TMP_Text  textbox;
    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            yield return new WaitForSeconds(3);
            textbox.text = ((collision.gameObject.transform.position.x * -1).ToString());
            //Destroy(collision.gameObject);
        }
        else
        {
            
        }

    }
}
