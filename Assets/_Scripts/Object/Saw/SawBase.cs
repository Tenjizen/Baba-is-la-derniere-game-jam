using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SawBase
{
    public enum StateBase { Up, Down, Left, Right };

    public Vector2Int CoordBaseSaw;

    public int TargetBaseUp;
    public int TargetBaseDown;
    public int TargetBaseRight;
    public int TargetBaseLeft;

    public StateBase EnumStateBase;
}
