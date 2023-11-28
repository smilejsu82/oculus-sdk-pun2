using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{
    public Grabber currentGrabber;
    
    public virtual void Grab(Grabber newGrabber)
    {
        
    }
}
