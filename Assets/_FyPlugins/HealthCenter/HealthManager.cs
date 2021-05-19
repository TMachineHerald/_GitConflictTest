using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fy_DataCenter
{
    public class HealthCenter
    {
        public float HealthNumber;

    }
    public partial class DataModel
    {
        public HealthCenter healthCenter;


        public HealthCenter HealthCenter
        {
            get
            {
                if (healthCenter == null)
                    healthCenter = new HealthCenter();
                return healthCenter;
            }
            set
            {
                healthCenter = value;
            }
        }
    }
}


