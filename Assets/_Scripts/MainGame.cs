using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    //public GameObject Player;
    //public GameObject PlayerMirror;
    public GameObject[] Prefabs;
    public GameObject[] PrefabsPlayer;
    public int Size;
    public float Distance;
    public int PtsSpawn;

    public int[,] Map;
    public Vector2Int[] PosWall;
    [HideInInspector] public List<Caisse> _caisse;
    public Vector2Int[] PosCaisse;
    //public Vector2Int[] PosScie;
    public bool Pause = false;

    public List<ScieBase> ListSaw = new List<ScieBase>();
    /*[HideInInspector]*/ public List<Scie> _saw;


    Vector3 offset;




    IEnumerator Start()
    {


        foreach (var item in PrefabsPlayer)
        {
            item.SetActive(false);
        }
        Map = new int[Size, Size];



        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                if (x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
                    Map[x, y] = 1;
            }
        }
        offset = new Vector3((Size * Distance) / 2, (Size * Distance) / 2);

        foreach (var pos in PosWall)
        {
            PosPrefab(pos, 1);
        }
        yield return PlaceMap();


        yield return PlaceBoxe();

        yield return PlaceSaw();

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
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                GameObject go = GameObject.Instantiate(Prefabs[Map[x, y]]);
                go.transform.position = new Vector3(x * Distance, y * Distance) - offset;
                go.transform.localScale = Vector3.zero;
                go.transform.DOScale(1, 0.3f);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceBoxe()
    {
        for (int i = 0; i < PosCaisse.Length; i++)
        {
            PosPrefab(PosCaisse[i], 2);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[PosCaisse[i].x, PosCaisse[i].y]]);
            _caisse.Add(FindObjectOfType<Caisse>());
            go2.transform.position = new Vector3(PosCaisse[i].x * Distance, PosCaisse[i].y * Distance) - offset;
            go2.transform.localScale = Vector3.zero;

            _caisse[i].coordCaisse = new Vector2Int(PosCaisse[i].x, PosCaisse[i].y);

            go2.transform.DOScale(0.5f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PlaceSaw()
    {
        for (int i = 0; i < ListSaw.Count; i++)
        {
            PosPrefab(ListSaw[i].coordBaseScie, 3);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[ListSaw[i].coordBaseScie.x, ListSaw[i].coordBaseScie.y]]);
            _saw.Add(FindObjectOfType<Scie>());
            go2.transform.position = new Vector3(ListSaw[i].coordBaseScie.x * Distance, ListSaw[i].coordBaseScie.y * Distance) - offset;
            go2.transform.localScale = Vector3.zero;


            _saw[i].coordScie = ListSaw[i].coordBaseScie;
            _saw[i].targetUp = ListSaw[i].targetBaseUp;
            _saw[i].targetDown = ListSaw[i].targetBaseDown;
            _saw[i].targetRight = ListSaw[i].targetBaseRight;
            _saw[i].targetLeft = ListSaw[i].targetBaseLeft;

            var jhgjd = (int)ListSaw[i].stateBase;
            _saw[i].state = 0;
            while (jhgjd != (int)_saw[i].state)
            {
                _saw[i].state += 1;
            }

            go2.transform.DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}