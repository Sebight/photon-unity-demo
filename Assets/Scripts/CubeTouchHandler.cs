using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CubeTouchHandler : MonoBehaviour
{
    public SphereCollider SphereCollider;

    private void Start()
    {
        SphereCollider = GetComponent<SphereCollider>();
    }

    // When something enters my trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("AAA");
            RoundManager.Instance.SetWinner(other.gameObject.GetComponent<PhotonView>().Owner);
            Destroy(gameObject);
        }
    }
}