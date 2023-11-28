using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkHand : MonoBehaviour, IPunObservable
{
    [SerializeField] private Animator anim;
    private float receiveFlex;
    private float receivePose;
    private float receivePinch;
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.anim.GetFloat("Flex"));
            stream.SendNext(this.anim.GetFloat("Pose"));
            stream.SendNext(this.anim.GetFloat("Pinch"));
        }
        else
        {
            this.receiveFlex = (float)stream.ReceiveNext();
            this.receivePose = (float)stream.ReceiveNext();
            this.receivePinch = (float)stream.ReceiveNext();
            
            Debug.LogFormat("{0}, {1}, {2}", this.receiveFlex, this.receivePose, this.receivePinch);
        }
    }
}
