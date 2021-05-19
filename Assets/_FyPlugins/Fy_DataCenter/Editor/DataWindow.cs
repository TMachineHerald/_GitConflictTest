using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEditor;
using Fy_DataCenter;

public class DataWindow
{
    [CustomEditor(typeof(dataWindow))]
    class dataWindow : Editor
    {
        [MenuItem("GameObject/FyMenu/dataWindow")]
        static void DemoMethod()
        {
            StaticWindow window = (StaticWindow)EditorWindow.GetWindow(typeof(StaticWindow));
            window.Show();
        }

    }



    class StaticWindow : EditorWindow
    {


        private void Awake()
        {
            // data
        }

        void OnGUI()
        {


        }
    }

}
