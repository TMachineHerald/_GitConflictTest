using UnityEditor;
using UnityEngine;
using System;
public class CustomKeys : Editor
{
    [MenuItem("FyTool/时间恢复 _F2")]
    static void EditorCustorkKeys2()
    {
        Debug.Log("时间恢复");
        Time.timeScale = 1;
    }


    [MenuItem("FyTool/截屏 _F1")]
    static void EditorCustorkKeys1()
    {
        Debug.Log("截图");


        string directoryName = Screen.width + "x" + Screen.height;
        string path = Application.dataPath.Replace("/Assets", "/" + Application.productName + "_Screenshot/" + directoryName);
        string imageName = directoryName + "_" + DateTime.Now.ToString("MMddHHmmff") + ".png";

        int fileCount = System.IO.File.Exists(path) ?
            new System.IO.DirectoryInfo(path).GetFiles().Length
            : System.IO.Directory.CreateDirectory(path).GetFiles().Length;

        ScreenCapture.CaptureScreenshot(path + "/" + imageName);
        imageName = "";
        Debug.Log("***截图成功:" + imageName + "  |***存放路径" + path + "  |***该尺寸数量" + (fileCount + 1));

    }
}
