using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJSON;
using FyEvent;
using System.IO;
using FyFile;
using Fy_DataCenter;

namespace Fy_DataCenter
{
    public partial class DataModel
    {
        CoinCenter coinCenter;

        public CoinCenter CoinCenter
        {
            get
            {
                if (coinCenter == null)
                    coinCenter = new CoinCenter();
                return coinCenter;
            }
            set
            {
                coinCenter = value;
            }
        }

    }

    public class CoinCenter
    {
        public int CoinNumber = 0;

    }
}
public class CoinManager : MonoBehaviour
{


    public int CoinNum;
    public static event IntEvent E_Collecting;
    private void Awake()
    {

    }
    void Start()
    {
    }



    public void OnCoinCollecting(int _Number)
    {
        E_Collecting?.Invoke(_Number);
    }

}
