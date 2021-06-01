using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class LoadData
{
    public string name;
    public DateTime dataTime;
    public List<SaveNode> nodes;

    public LoadData(string _name)
    {
        name = _name;
        dataTime = System.DateTime.Now;
    }

    public void ApllyData()
    {
        foreach (SaveNode node in nodes)
            node.Apply();
    }

    
}
