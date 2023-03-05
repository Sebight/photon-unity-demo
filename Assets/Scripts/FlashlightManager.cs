using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    public static FlashlightManager Instance;
    public Flashlight LocalFlashlightRef;

    private void Awake()
    {
        Instance = this;
    }

    public void ToggleFlashlight()
    {
        LocalFlashlightRef.ToggleFlashlight();
    }
}
