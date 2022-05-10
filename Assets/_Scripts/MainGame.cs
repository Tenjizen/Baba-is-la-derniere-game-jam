using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainGame : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    public GameObject[] Prefabs;
    public GameObject Player;
    public int Size;
    public float Distance;


    public int[,] map;

    public bool pause = false;

    IEnumerator Start()
    {
        map = new int[Size, Size];

        //        (distance de 0.64)
        //pop player en bas a gauche 
        //    Player.transform.position = new Vector2(((Size - Size + 1) - Size / 2) * Distance, ((Size - Size + 1) - Size / 2) * Distance);// map only paire genre 10, 20 ect
        //en bas a droite
        //    Player.transform.position = new Vector2(((Size - Size + (Size -2)) - Size / 2) * Distance, ((Size - Size + 1) - Size / 2) * Distance);// map only paire genre 10, 20 ect 
        //personnalisé
            Player.transform.position = new Vector2((_playerMove.coordPlayer.x - Size / 2) * Distance, (_playerMove.coordPlayer.y - Size / 2) * Distance);
        /*if (Size % 2 == 0)
            Player.transform.position = new Vector2(((Size - Size + 1) - Size / 2) * Distance, ((Size - Size + 1) - Size / 2) * Distance);// map only paire genre 10, 20 ect
        else
            Player.transform.position = new Vector2((((Size - Size + 1) - Size / 2) * Distance) - 0.32f, (((Size - Size + 1) - Size / 2) * Distance) - 0.32f);//map only impaire 11, 13 ect
*/
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
