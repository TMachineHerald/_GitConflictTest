using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FyEvent;

namespace Fy_DataCenter
{
    public partial class DataModel
    {
        public LevelData LevelData
        {
            get
            {
                if (levelData == null)
                    return new LevelData();
                else return levelData;
            }
            set
            {
                levelData = value;
            }
        }
        LevelData levelData;
    }

    public class LevelData
    {
        public int LevelNumber;
    }
}

public class LevelController : MonoSingleton<LevelController>
{
    GameObject currentLevel;
    public int CurrentLevelNum = 1;
    public Transform CurrentLevelInScene;

    private void Awake()
    {
        E_LevelRefresh += () =>
        {
            Fy_DataCenter.DataProcessor.Data.LevelData.LevelNumber = CurrentLevelNum;
        };
    }

    void Start()
    {
        //初始化关卡的进入
        FirstIntoLevel();

    }


    void Update()
    {


        //以下为测试阶段代码
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            nextLevel();
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {

        }

    }

    //第一次进入关卡
    public void FirstIntoLevel()
    {
        // #if UNITY_EDITOR //editor 下 , 直接在场景中配置关卡
        if (CurrentLevelInScene.childCount == 1)
        {
            Debug.LogWarning("Fy_log:当前存在测试关卡!");
            CurrentLevelNum = 0;
            currentLevel = CurrentLevelInScene.GetChild(0).gameObject;
            return;
        }
        else if (CurrentLevelInScene.childCount > 1)
        {
            Debug.LogError("Fy_log : Error ! Can not exist multiple GO under the [CurrentLevelInScene]");
        }
        // #endif

        GameObject _LevelResource = Resources.Load("LEVEL" + CurrentLevelNum.ToString()) as GameObject;
        if (_LevelResource == null)
            throw new System.Exception("空关卡引用");
        currentLevel = Instantiate(_LevelResource);
        currentLevel.transform.SetParent(CurrentLevelInScene);
        //初始化关卡数据
        LevelInit();
    }

    /// <summary>
    /// 切换至下一关卡 使用Resources.load 进行加载 
    /// </summary>
    void nextLevel(int _Level = -1)
    {

        currentLevel.SetActive(false);
        DestroyImmediate(currentLevel); //若且关卡卡顿, 改用普通Destroy();

        if (_Level == -1)
            CurrentLevelNum++;
        else
            CurrentLevelNum = _Level;

        GameObject _LevelResource = Resources.Load("LEVEL" + CurrentLevelNum.ToString()) as GameObject;
        if (_LevelResource == null)
        {
            //如果下一关为空 说明已经是最后一关  那么令下一关为第一关,重新获取资源
            CurrentLevelNum = 1;
            _LevelResource = Resources.Load("LEVEL" + CurrentLevelNum.ToString()) as GameObject;
        }
        StartCoroutine(DelayInit(_LevelResource));

    }

    /// <summary>
    /// 在一些情况下    导致了事件绑定的紊乱 (主要是awake中绑定的事件)  通过一帧延迟可以解决  如果一帧延迟解决不了   多来几帧 
    /// </summary>
    /// <param name="_LevelResource"></param>
    /// <returns></returns>
    IEnumerator DelayInit(GameObject _LevelResource)
    {
        yield return new WaitForFixedUpdate();
        currentLevel = Instantiate(_LevelResource);
        currentLevel.transform.SetParent(CurrentLevelInScene);
        // Debug.Log(currentLevel.transform.position);
        LevelInit();
    }


    /// <summary>
    /// 新关卡实例化后   一些场景中的复用物体的重新配置
    /// </summary>
    public event NoneEvent E_LevelRefresh;
    void LevelInit()
    {
        //设置游戏为正常状态

        E_LevelRefresh?.Invoke(); //触发关卡更新事件
    }



    /// <summary>
    /// 切换至下一关
    /// </summary>
    public void NextLevel()
    {
        nextLevel();
    }
    public void ReloadLevel()
    {
        nextLevel(CurrentLevelNum);
    }
    public void SkipToLevel(int _SkipToLevel)
    {
        nextLevel(_SkipToLevel);
    }
}
