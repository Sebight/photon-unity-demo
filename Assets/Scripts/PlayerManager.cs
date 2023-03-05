using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public GameObject LocalPlayerRef;
    public PhotonView PV;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (PV.IsMine)
        {
            // LocalPlayerRef = gameObject;
        }
    }

    void Start()
    {
    }

    private void Update()
    {
        // Handle ball throw
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            var forward = LocalPlayerRef.transform.forward;
            
            BallManager.Instance.ThrowBall(
                LocalPlayerRef.transform.position + new Vector3(0, 1f, 0) + forward, 
                Camera.main.transform.forward, 
                1000f);
        }
    }
}