using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkHand : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private PhotonView photonView;
    [SerializeField] private Animator anim;
    private float receiveFlex;
    private int receivePose;
    private float receivePinch;
    
    private void Update()
    {
        if (!this.photonView.IsMine)
        {
            this.anim.SetFloat("Flex", this.receiveFlex);
            this.anim.SetInteger("Pose", this.receivePose);
            this.anim.SetFloat("Pinch", this.receivePinch);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.anim.GetFloat("Flex"));
            stream.SendNext(this.anim.GetInteger("Pose"));
            stream.SendNext(this.anim.GetFloat("Pinch"));
        }
        else
        {
            this.receiveFlex = (float)stream.ReceiveNext();
            this.receivePose = (int)stream.ReceiveNext();
            this.receivePinch = (float)stream.ReceiveNext();
            
            Debug.LogFormat("{0}, {1}, {2}", this.receiveFlex, this.receivePose, this.receivePinch);
        }
    }
}
