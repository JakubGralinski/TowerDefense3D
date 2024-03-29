using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    public int StartMoney = 400;
    public int StartLives = 20;

    public static int Rounds;

    private void Start()
    {
        Money = StartMoney;
        Lives = StartLives;

        Rounds = 0;
    }
}
