using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public interface IHandRepresentation
{
    public void SetHandCommand(HandCommand command);
    public GameObject gameObject { get; }
    public void SetHandColor(Color color);
    public void SetHandMaterial(Material material);
    public void DisplayMesh(bool shouldDisplay);
    public bool IsMeshDisplayed { get; }
    public Material SharedHandMaterial { get; }

}

public class NetworkHand : MonoBehaviour, IPunObservable
{
    [SerializeField] private PhotonView photonView;
    [SerializeField] private Animator anim;
    [SerializeField] private NetworkRig rig;
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
            
            //Debug.LogFormat("{0}, {1}, {2}", this.receiveFlex, this.receivePose, this.receivePinch);
        }
    }
}
