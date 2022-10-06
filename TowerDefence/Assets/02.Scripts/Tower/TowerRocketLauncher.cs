using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerRocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private int _damage;

    [SerializeField] private float _reloadTime;
    private float _reloadTimer;

    protected override void Update()
    {
        base.Update();
        Reload();
    }

    private void Reload()
    {
        if (_reloadTimer < 0)
        {
            if (target != null)
            {
                Attack();
                _reloadTimer = _reloadTime;
            }
        }
        else
        {
            _reloadTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        for (int i = 0; i < _firePoints length; i++)
        {
            GameObject bullet = Object.instance.spawn
        }
    }

}
