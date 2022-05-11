using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    //[SerializeField] PlayerMove _playerMove;
    //public GameObject Player;
    //public GameObject PlayerMirror;
    public GameObject[] Prefabs;
    public GameObject[] PrefabsPlayer;
    public int Size;
    public float Distance;
    public int PtsSpawn;

    public int[,] Map;
    public Vector2Int[] PosWall;
    public Vector2Int[] PosCaisse;
    public bool Pause = false;


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
        Vector3 offset = new Vector3((Size * Distance) / 2, (Size * Distance) / 2);

        //GameObject.Instantiate(Prefabs[Map[5,5]]);
        foreach (var pos in PosWall)
        {
            PosPrefab(pos, 1);
        }

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

        //test
        foreach (var posCaisse in PosCaisse)
        {
            PosPrefab(posCaisse, 2);
            GameObject go2 = GameObject.Instantiate(Prefabs[Map[posCaisse.x, posCaisse.y]]);    
            go2.transform.position = new Vector3(posCaisse.x * Distance, posCaisse.y * Distance) - offset;
            go2.transform.localScale = Vector3.zero;

            go2.transform.DOScale(0.5f, 0.3f);
            yield return new WaitForSeconds(0.05f);

        }
        //end test
        
        foreach (var item in PrefabsPlayer)
        {
            item.SetActive(true);
        }
    }

    public void PosPrefab(Vector2Int pos, int prefab)
    {
        Map[pos.x, pos.y] = prefab;
    }
}