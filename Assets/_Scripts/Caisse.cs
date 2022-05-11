using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int coordCaisse;


    private void Start()
    {
        foreach (var item in _mainGame.PosCaisse)
        {
            coordCaisse = new Vector2Int(item.x, item.y);

        }

    }
}
