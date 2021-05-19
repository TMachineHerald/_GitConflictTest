using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyEditor
{
    [MenuItem("GameObject/FyMenu/CreateUI", priority = 0)]
    static void Init()
    {
        if (Selection.activeTransform)//现在层级面板中选择一个对象
        {
            GameObject gameObject = AssetDatabase.LoadAssetAtPath<GameObject>
            ("Assets/FyEditor/UI/UIPanel.prefab");
            if (gameObject != null)
            {
                // GameObject go = PrefabUtility.InstantiatePrefab(gameObject) as GameObject;
                GameObject go = GameObject.Instantiate(gameObject) as GameObject;
                go.transform.SetParent(Selection.activeTransform);
                go.GetComponent<RectTransform>().localPosition = Vector3.zero;
                go.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                go.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            }
            else
            {
                Debug.LogError("资源加载失败！！！");
            }
        }
    }


    [MenuItem("GameObject/FyMenu/light")]
    static void CreateWizard()
    {
        UIEditor window = (UIEditor)EditorWindow.GetWindow(typeof(UIEditor));
        window.Show();
    }
}




public class UIEditor : EditorWindow
{

    public float range = 500;
    public Color color = Color.red;
    public AnimationCurve curve;


    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Light lt = Selection.activeTransform.GetComponent<Light>();

            if (lt != null)
            {
                lt.color = Color.red;
            }
        }
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "uitext"))
        {
            Debug.Log("ui");
        };
        EditorGUI.TagField(new Rect(103, 103, 100, 100), "Finish");


    }


}