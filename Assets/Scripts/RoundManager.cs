using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    List<GameObject> Cubes = new List<GameObject>();

    public static RoundManager Instance;
    public GameObject RandomCubePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // SpawnCube();
        }
    }

    public void SpawnCube()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        Cubes.ForEach(
            cube => { PhotonNetwork.Destroy(cube); }
        );
        Vector3 randomOffset = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        GameObject randomCube = PhotonNetwork.Instantiate(RandomCubePrefab.name, Vector3.zero + randomOffset, Quaternion.identity);
        randomCube.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        Cubes.Add(randomCube);
    }

    public void SetWinner(Player player)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnCube();
        }
    }
}