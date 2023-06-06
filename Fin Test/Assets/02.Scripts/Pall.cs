using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pall : MonoBehaviour
{
   
    void Start()
    {
        for(int i =1; i <10; i++)
        {
            if(i%2!=0)
            {
                Debug.Log(i);
            }
        }
    }

    
}
