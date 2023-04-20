using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public static Player instance;

    private float _hp;
    public float _hpMax;
    public Slider _hpSlider;

    public float hp
    {
        set
        {
            if (value < 0)
                value = 0;

            _hp = value;
            _hpSlider.value = -_hp / _hpMax;


        }
        get
        {
            return _hp;
        }

    }
}
