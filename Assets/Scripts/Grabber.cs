using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public Grabbable grabbedObject;
    public NetworkGrabber networkGrabber;
    
    private HardwareHand hand;
    private HardwareRig rig;

    private Collider lastCheckedCollider;
    private Grabbable lastCheckColliderGrabbable;
    
    

    private void Awake()
    {
        this.rig = this.GetComponentInParent<HardwareRig>();
        this.hand = this.GetComponentInParent<HardwareHand>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Exit if an object is already grabbed
        if (this.grabbedObject != null)
        {
            // It is already the grabbed object or another, but we don't allow shared grabbing here
            return;
        }

        Grabbable grabbable;

        if (this.lastCheckedCollider == other)
        {
            grabbable = lastCheckColliderGrabbable;
        }
        else
        {
            grabbable = other.GetComponentInParent<Grabbable>();
        }
        
        // To limit the number of GetComponent calls, we cache the latest checked collider grabbable result
        lastCheckedCollider = other;
        lastCheckColliderGrabbable = grabbable;

        if (grabbable != null)
        {
            if (grabbable.currentGrabber != null)
            {
                // We don't allow multihand grabbing (it would have to be defined), nor hand swap (it would require to track hovering and do not allow grabbing while the hand is already close - or any other mecanism to avoid infinit swapping between the hands)
                return;
            }
            
            if (hand.isGrabbing) Grab(grabbable);
        }
    }

    public void Grab(Grabbable grabbable)
    {
        Debug.Log($"Try to grab object {grabbable.gameObject.name} with {gameObject.name}");
        grabbable.Grab(this);
        grabbedObject = grabbable;
    }
}
