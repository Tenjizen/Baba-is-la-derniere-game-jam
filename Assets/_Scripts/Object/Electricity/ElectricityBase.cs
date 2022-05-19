using UnityEngine;

[System.Serializable]
public class ElectricityBase
{
    public Vector2Int CoordBaseElectricity;
    public bool BaseOpen;

    public bool BaseHorizontal;
    public enum StateBase { Left, Right, Up, Down, Middle };
    public StateBase EnumBaseState;
}
