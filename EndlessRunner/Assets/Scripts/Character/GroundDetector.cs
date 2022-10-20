using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected;

    [SerializeField] private LayerMask _groundLayer;

    private void OnTriggerEnter(Collider other)
    {
        isDetected = true;
    }
    
    private
   
}
