using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T> 
{
    public enum Commands
    {
        Idle,
       Prepare,
       Casting,
       WaitForCastingFinished,
       Action,
       WaitForActionFinished,
       Finish,
       WaitForFinished,
    }
    public Commands current { get;  }

    public bool canExecute { get; }
    public T machineState { get; }

    public void Execute();
    

    public void Update();
    public void MoveNext();

}
