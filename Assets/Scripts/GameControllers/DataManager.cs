using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fy_DataCenter;




public class DataManager : MonoSingleton<DataManager>
{

    private void Awake()
    {
        LevelController.Instance.E_LevelRefresh += () =>
       {
           //    DataProcessor.Save();
       };
    }



}
