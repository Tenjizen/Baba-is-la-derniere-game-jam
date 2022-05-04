using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int coordPlayer;
    private void Start()
    {
        coordPlayer = new Vector2Int(1, 1);
        //this.transform.position = new Vector2((coordPlayer.x - _mainGame.Size / 2) * _mainGame.Distance, (coordPlayer.y - _mainGame.Size / 2) * _mainGame.Distance);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var pos = transform.position;

            if (_mainGame.map[coordPlayer.x, coordPlayer.y + 1] == 1)
            {
                print("mur en haut");
            }
            //else if (_mainGame.map[coordPlayer.x, coordPlayer.y + 1] == 2)
            //{

            //}
            else
            {
                pos = new Vector2(pos.x, pos.y + _mainGame.Distance);
                transform.position = pos;
                coordPlayer.y++;
            }


        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            var pos = transform.position;
            if (_mainGame.map[coordPlayer.x, coordPlayer.y - 1] == 1)
            {
                print("mur en bas");
            }

            else
            {
                pos = new Vector2(pos.x, pos.y - _mainGame.Distance);
                transform.position = pos;
                coordPlayer.y--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            var pos = transform.position;

            if (_mainGame.map[coordPlayer.x - 1, coordPlayer.y] == 1)
            {
                print("mur a gauche");
            }
            else
            {
                pos = new Vector2(pos.x - _mainGame.Distance, pos.y);
                transform.position = pos;
                coordPlayer.x--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var pos = transform.position;

            if (_mainGame.map[coordPlayer.x + 1, coordPlayer.y] == 1)
            {
                print("mur a droite");
            }
            else
            {
                pos = new Vector2(pos.x + _mainGame.Distance, pos.y);
                transform.position = pos;
                coordPlayer.x++;
            }
        }

    }
}
