using UnityEngine;

[System.Serializable]
public class DoorBase 
{
    public Vector2Int CoordBaseDoor;
    public bool BaseClose;
    public enum StateBase { Left, Right, Up, Down};
    public StateBase EnumBaseState;
}
