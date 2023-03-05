using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public PhotonView PV;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5);
        PV.RPC("DestroyBall", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void DestroyBall()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    public void Throw(Vector3 direction, float force)
    {
        Rigidbody.AddForce(direction * force);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // bump the player using lerping position
            // other.gameObject.GetComponent<Rigidbody>().AddForce(Rigidbody.velocity * 10);
            other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, other.gameObject.transform.position + Rigidbody.velocity, 0.5f);
        }
    }
}