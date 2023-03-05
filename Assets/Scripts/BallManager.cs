using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    public PhotonView PV;
    
    void Awake()
    {
        Instance = this;
        PV = GetComponent<PhotonView>();
    }

    public void ThrowBall(Vector3 transformPosition, Vector3 transformForward, float f)
    {
        Debug.Log("called ThrowBall");
        PV.RPC("ThrowNewBall", RpcTarget.MasterClient, transformPosition, transformForward, f);
    }

    [PunRPC]
    private void ThrowNewBall(Vector3 transformPosition, Vector3 transformForward, float f)
    {
        GameObject Ball = PhotonNetwork.Instantiate("Ball", transformPosition, Quaternion.identity);
        Ball.GetComponent<Ball>().Throw(transformForward, f);
    }
}