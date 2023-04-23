using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
