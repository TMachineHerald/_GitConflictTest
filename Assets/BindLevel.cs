using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class BindLevel : MonoBehaviour
{
    public LevelType BoundLevel;
    private void Awake()
    {

        LevelController.Instance.E_LevelRefresh += () =>
        {

            if (BoundLevel == LevelMessage.Instance.CurrentLevel)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        };
    }
}
