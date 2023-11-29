using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class HardwareHand : MonoBehaviour
{
    public RigPart side;
    public bool isGrabbing;
    public InteractorUnityEventWrapper eventWrapper;
    public NetworkHand networkHand;
    private HardwareRig rig;

    [SerializeField]
    private OVRInput.Controller controller;
    
    
    private void Awake()
    {
        this.rig = this.GetComponentInParent<HardwareRig>();
        
        this.eventWrapper.WhenSelect.AddListener(() =>
        {
            Debug.LogFormat("Grab");
        });
        this.eventWrapper.WhenUnselect.AddListener(() =>
        {
            Debug.LogFormat("UnGrab");
        });
    }

    private void Start()
    {
        Debug.LogFormat("networkHand: {0}", this.networkHand);
    }

    private void Update()
    {
        if (this.side == RigPart.RightController)
        {
            var flex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
            //var pinch = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
            
            if (this.rig != null && rig.networkRig != null)
            {
                this.rig.networkRig.SetRightHandFlex(flex);
                this.rig.networkRig.photonView.RPC("SetRightHandFlex", RpcTarget.Others, flex);
            }
        }
        else if (this.side == RigPart.LeftController)
        {
            var flex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
            //var pinch = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
            
            if (this.rig != null && rig.networkRig != null)
            {
                this.rig.networkRig.SetLeftHandFlex(flex);
                this.rig.networkRig.photonView.RPC("SetLeftHandFlex", RpcTarget.Others, flex);
            }
        }
    }
}
