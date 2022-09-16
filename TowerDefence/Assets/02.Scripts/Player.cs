using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int life;
    private int _money;
    public int money
    {
        get
        {
            return _money;
        }
        set
        {
            OnMoneyChanged();
            _money = value;
        }
    }
    public event Action OnMoneyChanged;

    public void SetUp( int life, int money)
    {
        this.life = life;
        this.money = money; 
    }

    private void Awake()
    {
        Instance = this;
    }
}
