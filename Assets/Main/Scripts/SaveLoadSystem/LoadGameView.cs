using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LoadGameView : MonoBehaviour, IViewAction<List<LoadData>>
{
    public event Action<List<LoadData>> ViewChanged;

    public Transform savesContent;
    public SaveView saveViewPreffab;
 
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetData(List<LoadData> data)
    {
        foreach (Transform child in savesContent)
            Destroy(child.gameObject);

        foreach (var save in data)
        {
            var temp = Instantiate(saveViewPreffab, savesContent);
            temp.GetComponent<SaveView>().Init(save);
        }
    }

    public List<LoadData> GetData()
    {
        return null;
    }


}
