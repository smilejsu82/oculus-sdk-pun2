using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkHand : MonoBehaviourPun
{
    public PhotonView photonView;
    public Animator anim;
    public NetworkRig rig;
    public RigPart side;
    
    private float receiveFlex;
    private int receivePose;
    private float receivePinch;

    public bool IsLocalNetworkRig => this.photonView.IsMine;
    
    public HardwareHand LocalHardwareHand => 
        IsLocalNetworkRig ? (side == RigPart.LeftController ? rig.hardwareRig.leftHand : rig.hardwareRig.rightHand) : null;

    private void Awake()
    {
        
    }

   
}
