using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Zenject;

[RequireComponent(typeof(IViewAction<List<LoadData>>))]
public class SaveLoad : MonoBehaviour
{
    private IViewAction<List<LoadData>> _saveLoadView;

    private List<LoadData> _allLoadData = new List<LoadData>();

    private LoadData _currentLoadData;

    private const string SAVE_DATA_PATH = "SaveData";

    [Inject]
    private void Construct()
    {       
       _saveLoadView = GetComponent<IViewAction<List<LoadData>>>();
    }

    public void OpenSaveLoad()
    {
        LoadAllData();
        _saveLoadView.Show();
    }

    public void LoadAllData()
    {
        SaveFolderIsExists(Application.persistentDataPath + "/" + SAVE_DATA_PATH);
        string[] savesNames = Directory.GetFiles(Application.persistentDataPath + "/" + SAVE_DATA_PATH  + "/");

        List<LoadData> savesTemp = new List<LoadData>();
        foreach(var savesPath in savesNames)
        {
            savesTemp.Add(BinaryLoad(savesPath));
        }
        _saveLoadView.SetData(savesTemp);
    }

    public void SaveCurrentData(string name)
    {
        _currentLoadData = new LoadData(name);
        BinarySave(_currentLoadData);
    }

    public void LoadCurrentData(string path)
    {
        _currentLoadData = BinaryLoad(path);
        _currentLoadData.ApllyData();
    }

    private string GetActualPathForSave(LoadData data)
    {
        return Application.persistentDataPath + "/" + SAVE_DATA_PATH + "/" + data.name + ".save";
    }

    private bool SaveFolderIsExists(string path)
    {
        if (File.Exists(path))
        {           
            return true;
        }
        else
        {
            Directory.CreateDirectory(path);
            return false;
        }
    }

    private void BinarySave(LoadData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetActualPathForSave(data));
        bf.Serialize(file, data);
        file.Close();
    }

    private LoadData BinaryLoad(string path)
    {
        LoadData result = null;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            result = (LoadData)bf.Deserialize(file);
            file.Close();
        }

        return result;
    }
}
