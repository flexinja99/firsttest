using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    private float _hp;
    [SerializeField]private float _hpMax;
    [SerializeField]private Slider _hpSlider;

    public float hp
    {
        set
        {
            if( value <0)
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
