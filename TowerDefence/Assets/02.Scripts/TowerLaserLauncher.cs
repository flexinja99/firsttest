using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TowerLaserLauncher : Tower
{
    [SerializeField] private LineRenderer _laserBeam;
    [SerializeField] private ParticleSystem _laserHitEffect;
    [SerializeField] private Transform _firePoint;

    private float _damageStep;
    private int DamageStep
    {
        set
        {
            _damageStep = value;
            _laserBeam.startWidth = 0.05f * (1 + _damageStep);
            _laserBeam.endWidth = 0.05f * (1 + _damageStep);
        }
    }




    [SerializeField] private int _damageGain;
    [SerializeField] private float _damageChargeTime;
    private float _damageChargeTimer;

    //공격구현
    private void Attack()
    {
        if(target == null)
        {
            _laserBeam.enabled = false;
            _laserHitEffect.Stop();
        }
        else
        {
            _laserBeam.SetPosition(0, _firePoint.position);
            _laserBeam.SetPosition(1, target.position);
            _laserBeam.enabled = true;

            if (_laserHitEffect.isStopped)
                _laserHitEffect.Play();

          RaycastHit[] hits =  Physics.RaycastAll(origin: _firePoint.position,
                               direction: target.position - _firePoint.position,
                               maxDistance: Vector3.Distance(target.position, _firePoint.position),
                               layerMask: _targetLayer);

            for (int i = 0; i < hits.Length; i++)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                if (hits[i].collider.transform == target)
                {
                    _laserHitEffect.transform.position = hits[i].collider.transform.position;
                    _laserHitEffect.transform.LookAt(_firePoint);
                    break;
                }
            }

            target.GetComponent<Enemy>().hp -= (int)_damageStep * (1 + _damageStep) * _damageGain * Time.deltaTime);

            if (_damageChargeTimer < 0 &&
                _damageStep <2)
            {
                _damageStep++;
                _damageChargeTimer = _damageChargeTime;
            }
            else
            {
                _damageChargeTimer -= Time.deltaTime;
            }

            
           
        }
    }

}
