using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SB.Runtime {
    public struct SInteractionTaskData
    {
        public bool interacted;
        public float interactionTime;
    }

    public struct SFlowerData
    {
        public bool bloomed;
        public int style;
        public void FlowerData(bool bloomed = false, int style = 0)
        {
            this.bloomed = bloomed;
            this.style = style;
        }
    }
}