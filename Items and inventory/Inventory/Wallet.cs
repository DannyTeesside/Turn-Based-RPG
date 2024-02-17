using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    [SerializeField] float startingBalance = 500f;

    float balance = 0;

    public event Action onChange;

    private void Awake()
    {
        balance = startingBalance;
    }

    public float GetBalance()
    {
        return balance;
    }

    public void UpdateBalance(float amount)
    {
        balance += amount;
        if (onChange != null)
        {
            onChange();
        }
    }
}
