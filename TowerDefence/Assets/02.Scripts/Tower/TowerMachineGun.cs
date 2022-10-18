using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMachineGun : Tower
{
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
        for (int i = 0; i < _firePoints.Length; i++)
        {
            GameObject bullet = ObjectPool.instance.Spawn("Bullet", _firePoints[i].position);

            bullet.GetComponent<ProjectileBullet>()
                .SetUp(target,
                       15.0f,
                       _damage,
                       true,
                       touchLayer,
                       targetLayer);
        }
    }
}
