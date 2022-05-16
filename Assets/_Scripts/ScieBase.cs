using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScieBase
{
    public enum StateBase { Up, Down, Left, Right };

    public Vector2Int coordBaseScie;

    public int targetBaseUp;
    public int targetBaseDown;
    public int targetBaseRight;
    public int targetBaseLeft;

    public StateBase stateBase;
}
