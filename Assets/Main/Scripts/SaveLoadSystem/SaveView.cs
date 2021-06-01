using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveView : MonoBehaviour
{
    public Text Name;
    public Text Data;

    public void Init(LoadData data)
    {
        Name.text = data.name;
        Data.text = data.dataTime.ToString();
    }
}
