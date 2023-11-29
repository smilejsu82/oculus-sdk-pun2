using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkGrabbable : MonoBehaviour, IPunOwnershipCallbacks
{
    public InteractableUnityEventWrapper eventWrapper;
    public PhotonView pv;    
    void Start()
    {
        this.eventWrapper.WhenSelect.AddListener(() =>
        {
            Debug.Log("<color=lime>Grab</color>");
            this.pv.RequestOwnership();
        });    
        this.eventWrapper.WhenUnselect.AddListener(() =>
        {
            Debug.Log("<color=lime>UnGrab</color>");
        });
    }
    void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        Debug.LogFormat("<color=yellow>OnOwnershipRequest: {0}, {1}</color>", targetView.name, requestingPlayer.NickName);
        this.pv.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.LogFormat("<color=yellow>OnOwnershipTransfered: {0}, {1}</color>", targetView.name, previousOwner?.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        Debug.LogFormat("<color=yellow>OnOwnershipTransferFailed: {0}, {1}</color>", targetView.name, senderOfFailedRequest.NickName);
    }
}
