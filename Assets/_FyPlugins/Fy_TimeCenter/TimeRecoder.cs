using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fy_DataCenter;
using System;
using System.Globalization;
using UnityEditor;
namespace Fy_DataCenter
{
    public partial class DataModel
    {
        public string LastTime = "";
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(TimeRecoder))]
class InspectorEditor2 : Editor
{
    //重写OnInspectorGUI类(刷新Inspector面板)
    public override void OnInspectorGUI()
    {
        //继承基类方法
        base.OnInspectorGUI();

        //获取要执行方法的类
        TimeRecoder targetScript = (TimeRecoder)target;
        //绘制Button
        GUILayout.Label("本脚本用于记录最后一次打开游戏的时间\n并提示多久没有运行了");
    }
}
#endif

//本脚本用于记录上次打开游戏到这次进入游戏中间间隔了多长时间
public class TimeRecoder : MonoBehaviour
{

    string time;
    DateTime nowTime;
    DateTime lastTime;

    [ContextMenu("My Func", false)]
    public void TestFunc()
    {
        Debug.Log("test string : " + lastTime);
    }

    void Start()
    {

        //自定义格式化
        // DateTime dt;
        // DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
        // dtFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";




        nowTime = DateTime.Now;

        if (DataProcessor.Data.LastTime != "")
        {
            lastTime = Convert.ToDateTime(DataProcessor.Data.LastTime);//, dtFormat);
        }

        time = nowTime.ToString("yyyy-MM-dd HH:mm:ss");


        TimeSpan sp = nowTime.Subtract(lastTime);
        // Debug.Log(sp.Days + "  " + sp.Hours + "  " + sp.Minutes + "  " + sp.Seconds);

        string logMessage = "";
        if (sp.Days > 0)
        {
            logMessage = $"You haven't been play for {sp.Days} days";
        }
        else if (sp.Hours > 3)
        {
            logMessage = $"You haven't been play for {sp.Hours} hours";
        }

#if UNITY_EDITOR
        else if (sp.Minutes >= 1)
        {
            logMessage = $"You haven't been play for {sp.Minutes} minutes";
        }
#endif

        Debug.Log(logMessage);

        DataProcessor.Data.LastTime = time;
        DataProcessor.Save();
    }

}
