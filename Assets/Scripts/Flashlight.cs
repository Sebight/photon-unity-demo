using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light FlashlightLight;
    public PhotonView PV;
    
    private void Awake()
    {
        FlashlightLight = GetComponent<Light>();
        PV = GetComponent<PhotonView>();
    }

    public void ToggleFlashlight()
    {
        PV.RPC("ToggleFlashlightRPC", RpcTarget.All);
    }

    [PunRPC]
    public void ToggleFlashlightRPC()
    {
        FlashlightLight.enabled = !FlashlightLight.enabled;
    }
}