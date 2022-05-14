using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour
{
    public Vector2Int coordCaisse;
    [SerializeField] MainGame _mainGame;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }


    private void Update()
    {

            
    }

    public void CheckMoveUp()
    {
        var pos = transform.position;

        if (_mainGame.Map[coordCaisse.x, coordCaisse.y + 1] != 1)
        {
            print("mur en haut");
        }
        else
        {
            pos = new Vector2(pos.x, pos.y + _mainGame.Distance);
            transform.position = pos;
            coordCaisse.y++;
        }
    }
    public void CheckMoveDown()
    {
        var pos = transform.position;
        if (_mainGame.Map[coordCaisse.x, coordCaisse.y - 1] == 1)
        {
            print("mur en bas");
        }
        else
        {
            pos = new Vector2(pos.x, pos.y - _mainGame.Distance);
            transform.position = pos;
            coordCaisse.y--;
        }
    }





}
