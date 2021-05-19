using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
namespace FyFile
{
    public enum FileTypes
    {
        Json,

        txt
    }
    public enum SaveMode
    {
        Override,

        Create,
        OverrideOrCreate
    }
    public class FileManager
    {


        public static void SaveStringToFile(string _Data, string _Path, SaveMode _Savemode = SaveMode.OverrideOrCreate)
        {


            if (File.Exists(_Path) && _Savemode == SaveMode.Create)
            {
                Debug.LogError($"Exist File but you wanna create new {_Path}");
                return;
            }
            else if (File.Exists(_Path) && _Savemode == SaveMode.Override)
            {
                // do nothing
            }
            else if (!File.Exists(_Path) && _Savemode == SaveMode.Override)
            {
                Debug.LogError($"No File but you wanna override {_Path}");
                return;
            }

            if (!File.Exists(_Path) && (_Savemode == SaveMode.OverrideOrCreate || _Savemode == SaveMode.Create))
            {
                Debug.LogWarning($"Create {_Path}");
                FileStream _FS = File.Create(_Path);
                _FS.Flush();
                _FS.Close();
                Debug.Log("EndCreate");
            }
            StreamWriter _SW = new StreamWriter(_Path);
            Debug.Log("Before Write");
            _SW.Write(_Data);

            //刷新缓存
            _SW.Flush();
            _SW.Close();
        }

        public static string LoadFileToString(string _Path)
        {


            StreamReader _SR;
            if (File.Exists(_Path))
            {
                _SR = new StreamReader(_Path);
            }
            else
            {
                SaveStringToFile("{}", _Path);
                _SR = new StreamReader(_Path);
            }

            string _DataString = _SR.ReadToEnd();
            _SR.Close();
            return _DataString;
        }
    }
}