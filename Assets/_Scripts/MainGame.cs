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
    public int Size;
    public float Distance;
    public int PtsSpawn;

    public int[,] Map;

    public bool Pause = false;


    IEnumerator Start()
    {
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

}