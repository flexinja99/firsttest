using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHp 
{
    int hp { get; set; }
   event Action<int> OnHPChanged;
    
}
