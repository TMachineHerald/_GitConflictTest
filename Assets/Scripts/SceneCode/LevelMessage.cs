using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    Type1,
    Type2,
}
/// <summary>
/// 这个脚本挂载在关卡上,用于记录关卡的具体信息,如果是集合类游戏,还可以用LevelType来记录种类,
/// 在别的脚本中通过种类来进行功能区分
/// </summary>
public class LevelMessage : MonoSingleton<LevelMessage>
{
    public LevelType LevelType;

    public LevelType CurrentLevel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
