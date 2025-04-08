using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public struct SInteractionData
{
    public bool interacted;
    public float interactionPercent;
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
