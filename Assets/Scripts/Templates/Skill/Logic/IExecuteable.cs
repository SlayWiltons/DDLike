using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecuteable
{
    void OnStartExecute();
    void OnProceedExecute();
    void OnEndExecute();
}
