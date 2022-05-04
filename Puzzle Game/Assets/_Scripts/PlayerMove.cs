using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var pos = transform.position;
            pos.y = transform.position.y + _mainGame.Distance;
            if (_mainGame.map[pos.x,pos.y]!=1)
            {

                transform.position = pos;
            }



        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            var pos = transform.position;
            pos.y = transform.position.y - _mainGame.Distance;
            transform.position = pos;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            var pos = transform.position;
            pos.x = transform.position.x - _mainGame.Distance;
            transform.position = pos;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            var pos = transform.position;
            pos.x = transform.position.x + _mainGame.Distance;
            transform.position = pos;
        }

    }
}
