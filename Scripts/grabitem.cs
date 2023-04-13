using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabitem : MonoBehaviour
{
   
    private Rigidbody rb;
    
    private GameObject target;
    private bool inrange = false;
    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
         
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                rb.useGravity = false;
                rb.isKinematic = true;
                target.transform.parent = this.transform;
              
            }
            if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
            {
                target.transform.parent = null;
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * 3;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("grab"))
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            target = other.gameObject;
            inrange = true;
           
            
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        inrange = false;
    }
}
