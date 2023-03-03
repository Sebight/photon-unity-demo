using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

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
        else
        {
            Destroy(gameObject);
        }
        
        if (PV.IsMine)
        {
            LocalPlayerRef = gameObject;
        }
    }
    
    void Start()
    {
        Instance = this;
    }
}
