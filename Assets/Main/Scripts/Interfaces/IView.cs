using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView <T> : IView
{
    void SetData(T data);

    T GetData();
}

public interface IView
{
    void Show();

    void Hide();

   
}
