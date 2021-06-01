using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IViewAction<T> : IView<T>
{
    event Action<T> ViewChanged;
}
