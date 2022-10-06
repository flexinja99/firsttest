using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ProjectTileRocket : Projectile
{
    [SerializeField] private ParticleSystem _explosionEffect;
    private float _explosionRange;

    protected overrride private void OnTriggerEnter(Collider other)
    {
        if(1 << other.gameObject.layer == targetLayer)
    }
}


