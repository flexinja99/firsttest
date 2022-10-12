using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBurning<T> : IBuff<T>
{
    private int _damage;
    private int _term;

    public BuffBurning(int damage, float term)
    {
        _damage = damage;
        _term = term;
        _timer = _term;
    }


    public void OnActive(T target)
    {
        
    }

    public void OnDeactive(T target)
    {
        if (target is IHp)
        {

        }
    }

    public void OnDuration(T target)
    {
        throw new System.NotImplementedException();
    }
}
