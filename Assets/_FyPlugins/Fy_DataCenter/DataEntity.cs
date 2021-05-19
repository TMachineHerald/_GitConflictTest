using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FyFile;

/// <summary>
/// 注意 : Json转化的实质是数据实例   而非  数据类型
///  如果类型 是 Class  , 需要 进行实例化
/// </summary>
namespace Fy_DataCenter
{
    using LitJSON;
    public partial class DataModel
    {
        public DataModel()
        {
            Enemy = new Enemy(21, "NameFy");
        }
        public string ActorName;


        public Enemy Enemy;



        public V3Data V3Data_2;
        V3Data _v3data;
        public V3Data V3Data_1
        {
            set
            {
                _v3data = value;
            }
            get
            {
                if (_v3data == null)
                    _v3data = new V3Data(Vector3.zero);
                return _v3data;
            }
        }
    }

    public class V3Data
    {
        public V3Data(Vector3 _Data)
        {
            x = _Data.x;
            y = _Data.y;
            z = _Data.z;
        }
        public V3Data()
        {
            x = y = z = 0;
        }
        public void SetVector3(V3Data _Data)
        {
            x = _Data.x;
            y = _Data.y;
            z = _Data.z;
        }
        public Vector3 GetVector3()
        {
            return new Vector3(x, y, z);
        }

        public float x;
        public float y;
        public float z;
    }


    public class Enemy
    {
        public Enemy(int _Health, string _Name)
        {
            Health = _Health;
            Name = _Name;
        }

        public Enemy()
        {
        }
        public int Health = 0;
        public string Name = "Monster";
    }











    #region Tool
    public class DataProcessor
    {

        static DataModel _Data;
        public static DataModel Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = getData();
                    if (_Data == null)
                    {
                        throw new ArgumentException("未能成功获取_Data");
                    }

                }
                return _Data;
            }
        }


#if UNITY_EDITOR
        static string _Path = Application.dataPath + $"/_FyPlugins/Fy_DataCenter/BaseDataJson.Json";
#else
        static string _Path = Application.persistentDataPath + $"/BaseDataJson.Json";
#endif

        public static void Save()
        {
            string _DataString = LitJson.JsonMapper.ToJson(Data);


            FileManager.SaveStringToFile(_DataString, _Path);
        }


        static DataModel getData()
        {
            string _DataString = FileManager.LoadFileToString(_Path);
            DataModel _DataModel = LitJson.JsonMapper.ToObject<DataModel>(_DataString);
            if (_DataModel == null)
            {
                throw new ArgumentException("请检查Json文件的数据格式! 至少为一个空对象: ----{}");
            }

            return _DataModel;
        }



        // public IEnumerator GetEnumerator()
        // {
        //     string _DataString = FileManager.LoadFileToString(_Path);

        //     LitJson.JsonReader _Reader = new LitJson.JsonReader(_DataString);

        //     while (_Reader.Read())
        //     {
        //         string type = _Reader.Value != null ?
        //             _Reader.Value.GetType().ToString() : "";

        //         Debug.Log($"_Reader.Token: { _Reader.Token}  ||_Reader.Value:{_Reader.Value} ||type:{type}");

        //     }
        //     yield return 1;

        //     yield return 54;
        // }
    }
    #endregion




}


