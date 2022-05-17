using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class TreadmillBase 
{
    public enum StateBase { Up, Down, Left, Right };
    public Vector2Int CoordBaseTreadmill;

    public StateBase EnumStateBase;
}
