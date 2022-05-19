using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int CoordSwitch;
    public bool Open;

    public List<Vector2Int> target;


    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }

    private void Update()
    {
        foreach (var player in _mainGame.Player)
        {
            if (player.CoordPlayer == CoordSwitch && Input.GetKeyDown(KeyCode.E))
            {
                Open = !Open;

                for (int i = 0; i < target.Count; i++)
                {
                    foreach (var item in _mainGame.Door)
                    {
                        if (item.CoordDoor == target[i])
                        {
                            item.Close = !item.Close;
                        }
                    }
                    foreach (var item in _mainGame.Electricity)
                    {
                        if (item.CoordElectricity == target[i])
                        {
                            item.Open = !item.Open;
                        }
                    }
                }
            }
        }
    }


}
