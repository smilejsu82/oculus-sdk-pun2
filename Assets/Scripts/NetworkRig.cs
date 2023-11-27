using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkRig : MonoBehaviour
{
    private PhotonView photonView;
    public HardwareRig hardwareRig;
    public NetworkHead headset;
    public NetworkHand leftHand;
    public NetworkHand rightHand;

    private void Awake()
    {
        this.photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) {
            this.hardwareRig = FindObjectOfType<HardwareRig>();
            if (this.hardwareRig == null) {
                Debug.LogError("Missing HardwareRig in the Scene");
            }
        }
    }

    private void FixedUpdate()
    {
        if(this.photonView.IsMine)
        {
            this.transform.position = this.hardwareRig.transform.position;
            this.headset.transform.position = this.hardwareRig.headset.transform.position;
            this.leftHand.transform.position = this.hardwareRig.leftHand.transform.position;
            this.rightHand.transform.position = this.hardwareRig.rightHand.transform.position;
        }
    }

}
