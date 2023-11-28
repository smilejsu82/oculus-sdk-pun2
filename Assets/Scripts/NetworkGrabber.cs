using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
 
public class NetworkGrabber : MonoBehaviour, IPunObservable
{
    public NetworkHand hand;
    private void Awake()
    {
        this.hand = GetComponentInParent<NetworkHand>();
        Debug.LogFormat("NetworkGrabber: {0}", hand);
    }

    private void Start()
    {
        if (this.hand.IsLocalNetworkRig)
        {
            
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
