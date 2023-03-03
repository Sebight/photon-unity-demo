using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        PhotonNetwork.Instantiate(PlayerPrefab.name, Vector3.zero + randomOffset, Quaternion.identity);
    }
}