using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{

    public bool Pause = false;
    public GameObject[] Prefabs;
    public GameObject[] PrefabsPlayer;
    public int Wight;
    public int Hight;
    public float Distance;
    public int PtsSpawn;

    public int[,] Map;
    public Vector2Int[] PosWall;
    public Vector2Int[] PosBox;
    public List<SawBase> ListSaw = new List<SawBase>();
    public List<TreadmillBase> ListTreadmill = new List<TreadmillBase>();
    public List<DoorBase> ListDoor = new List<DoorBase>();
    public List<ElectricityBase> ListElectricity = new List<ElectricityBase>();
    public List<SwitchBase> ListSwitch = new List<SwitchBase>();

    [HideInInspector] public List<PlayerMove> Player;
    [HideInInspector] public List<Box> Box;
    [HideInInspector] public List<Saw> Saw;
    [HideInInspector] public List<Treadmill> Treadmill;
    [HideInInspector] public List<Door> Door;
    [HideInInspector] public List<Electricity> Electricity;
    [HideInInspector] public List<Switch> Switch;


    private Vector3 _offset;


    IEnumerator Start()
    {
        foreach (var item in PrefabsPlayer)
        {
            Player.Add(FindObjectOfType<PlayerMove>());
            item.SetActive(false);
        }
        Map = new int[Wight, Hight];

        for (int x = 0; x < Wight; x++)
        {
            for (int y = 0; y < Hight; y++)
            {
                if (x == 0 || x == Wight - 1 || y == 0 || y == Hight - 1)
                    Map[x, y] = 1;
            }
        }
        _offset = new Vector3((Wight * Distance) / 2, (Hight * Distance) / 2);

        foreach (var pos in PosWall)
        {
            PosPrefab(pos, 1);
        }

        yield return PlaceMap();

        yield return PlaceBox();

        yield return PlaceSaw();

        yield return PlaceTreadmill();

        yield return PlaceDoor();

        yield return PlaceElectricity();

        yield return PlaceSwitch();

        foreach (var item in PrefabsPlayer)
        {
            item.SetActive(true);
        }
    }

    public void PosPrefab(Vector2Int pos, int prefab)
    {
        Map[pos.x, pos.y] = prefab;
    }

    IEnumerator PlaceMap()
    {
        for (int x = 0; x < Wight; x++)
        {
            for (int y = 0; y < Hight; y++)
            {
                GameObject go = GameObject.Instantiate(Prefabs[Map[x, y]]);
                go.transform.position = new Vector3(x * Distance, y * Distance) - _offset;
                go.transform.localScale = Vector3.zero;
                go.transform.DOScale(1, 0.3f);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceBox()
    {
        for (int i = 0; i < PosBox.Length; i++)
        {
            PosPrefab(PosBox[i], 2);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[PosBox[i].x, PosBox[i].y]]);
            Box.Add(FindObjectOfType<Box>());
            go2.transform.position = new Vector3(PosBox[i].x * Distance, PosBox[i].y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;

            Box[i].CoordBox = new Vector2Int(PosBox[i].x, PosBox[i].y);

            go2.transform.DOScale(0.5f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceSaw()
    {
        for (int i = 0; i < ListSaw.Count; i++)
        {
            PosPrefab(ListSaw[i].CoordBaseSaw, 3);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListSaw[i].CoordBaseSaw.x, ListSaw[i].CoordBaseSaw.y]]);
            Saw.Add(FindObjectOfType<Saw>());
            go2.transform.position = new Vector3(ListSaw[i].CoordBaseSaw.x * Distance, ListSaw[i].CoordBaseSaw.y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;


            Saw[i].CoordSaw = ListSaw[i].CoordBaseSaw;
            Saw[i].TargetUp = ListSaw[i].TargetBaseUp;
            Saw[i].TargetDown = ListSaw[i].TargetBaseDown;
            Saw[i].TargetRight = ListSaw[i].TargetBaseRight;
            Saw[i].TargetLeft = ListSaw[i].TargetBaseLeft;

            var enumSaw = (int)ListSaw[i].EnumStateBase;
            Saw[i].EnumState = 0;
            while (enumSaw != (int)Saw[i].EnumState)
            {
                Saw[i].EnumState += 1;
            }

            go2.transform.DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator PlaceTreadmill()
    {
        for (int i = 0; i < ListTreadmill.Count; i++)
        {

            PosPrefab(ListTreadmill[i].CoordBaseTreadmill, 5);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListTreadmill[i].CoordBaseTreadmill.x, ListTreadmill[i].CoordBaseTreadmill.y]]);
            Treadmill.Add(FindObjectOfType<Treadmill>());
            go2.transform.position = new Vector3(ListTreadmill[i].CoordBaseTreadmill.x * Distance, ListTreadmill[i].CoordBaseTreadmill.y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;

            Treadmill[i].CoordTreadmill = ListTreadmill[i].CoordBaseTreadmill;

            var enumTreadmill = (int)ListTreadmill[i].EnumStateBase;
            Treadmill[i].EnumState = 0;
            while (enumTreadmill != (int)Treadmill[i].EnumState)
            {
                Treadmill[i].EnumState += 1;
            }

            go2.transform.DOScale(0.5f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator PlaceDoor()
    {
        for (int i = 0; i < ListDoor.Count; i++)
        {
            PosPrefab(ListDoor[i].CoordBaseDoor, 6);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListDoor[i].CoordBaseDoor.x, ListDoor[i].CoordBaseDoor.y]]);
            Door.Add(FindObjectOfType<Door>());
            go2.transform.position = new Vector3(ListDoor[i].CoordBaseDoor.x * Distance, ListDoor[i].CoordBaseDoor.y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;

            Door[i].CoordDoor = ListDoor[i].CoordBaseDoor;
            Door[i].Close = ListDoor[i].BaseClose;

            go2.transform.DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceElectricity()
    {
        for (int i = 0; i < ListElectricity.Count; i++)
        {
            PosPrefab(ListElectricity[i].CoordBaseElectricity, 7);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListElectricity[i].CoordBaseElectricity.x, ListElectricity[i].CoordBaseElectricity.y]]);
            Electricity.Add(FindObjectOfType<Electricity>());
            go2.transform.position = new Vector3(ListElectricity[i].CoordBaseElectricity.x * Distance, ListElectricity[i].CoordBaseElectricity.y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;

            Electricity[i].CoordElectricity = ListElectricity[i].CoordBaseElectricity;
            Electricity[i].Open = ListElectricity[i].BaseOpen;

            go2.transform.DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceSwitch()
    {
        for (int i = 0; i < ListSwitch.Count; i++)
        {
            PosPrefab(ListSwitch[i].CoordBaseSwitch, 8);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListSwitch[i].CoordBaseSwitch.x, ListSwitch[i].CoordBaseSwitch.y]]);
            Switch.Add(FindObjectOfType<Switch>());
            go2.transform.position = new Vector3(ListSwitch[i].CoordBaseSwitch.x * Distance, ListSwitch[i].CoordBaseSwitch.y * Distance) - _offset;
            go2.transform.localScale = Vector3.zero;

            Switch[i].CoordSwitch = ListSwitch[i].CoordBaseSwitch;
            Switch[i].Open = ListSwitch[i].BaseOpen;


            //test
            for (int u = 0; u < ListSwitch[i].target.Length; u++)
            {

                Switch[i].target.Add(ListSwitch[i].target[u]);
            }
            //endtest



            go2.transform.DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }


}