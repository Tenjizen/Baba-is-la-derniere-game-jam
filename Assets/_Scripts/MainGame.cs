using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    public GameObject[] Prefabs;
    public GameObject Player;
    public int Size = 10;
    public float Distance = 1;


    public int[,] map;

    public bool pause = false;

    IEnumerator Start()
    {
        map = new int[Size, Size];

        Player.transform.position = new Vector2((_playerMove.coordPlayer.x - Size / 2) * Distance, (_playerMove.coordPlayer.y - Size / 2) * Distance);//pop player en bas a gauche

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                if (x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
                    map[x, y] = 1;
            }
        }

        Vector3 offset = new Vector3((Size * Distance) / 2, (Size * Distance) / 2);


        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                GameObject go = GameObject.Instantiate(Prefabs[map[x, y]]);
                go.transform.position = new Vector3(x * Distance, y * Distance) - offset;
                go.transform.localScale = Vector3.zero;

                go.transform.DOScale(1, 0.3f);
            }
            yield return new WaitForSeconds(0.05f);
        }

    }

}
