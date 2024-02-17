using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLoad : MonoBehaviour
{

    [SerializeField] int scene = 0;

    private void Awake()
    {
        Debug.Log(scene + " Loaded");
    }
}
