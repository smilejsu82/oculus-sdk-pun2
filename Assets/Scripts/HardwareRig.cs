using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RigPart
{
    None,
    Headset,
    LeftController,
    RightController,
    Undefined

}

public class HardwareRig : MonoBehaviour
{
    public HardwareHead headset;
    public HardwareHand leftHand;
    public HardwareHand rightHand;

    public NetworkRig networkRig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
