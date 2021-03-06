using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public enum State { Up, Down, Left, Right };
    public State EnumState;

    public SpriteRenderer SelfImage;
    public Sprite[] SpriteOnOff;

    public bool On;

    public Vector2Int CoordTreadmill;


    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();

    }

    void Update()
    {

        if (On)
        {

            foreach (var player in _mainGame.Player)
            {

                var posItem = player.transform.position;

                if (player.CoordPlayer == CoordTreadmill)
                {
                    switch (EnumState)
                    {
                        case State.Up:
                            posItem = new Vector2(posItem.x, posItem.y + _mainGame.Distance);
                            player.transform.position = posItem;
                            player.CoordPlayer.y++;
                            foreach (var box in _mainGame.Box)
                            {
                                var posBoxItem = box.transform.position;
                                if (box.CoordBox == player.CoordPlayer)
                                {
                                    posBoxItem = new Vector2(posBoxItem.x, posBoxItem.y + _mainGame.Distance);
                                    box.transform.position = posBoxItem;
                                    box.CoordBox.y++;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y - 1] = 0;
                                }
                            }
                            break;
                        case State.Down:
                            posItem = new Vector2(posItem.x, posItem.y - _mainGame.Distance);
                            player.transform.position = posItem;
                            player.CoordPlayer.y--;
                            foreach (var box in _mainGame.Box)
                            {
                                var posBoxItem = box.transform.position;
                                if (box.CoordBox == player.CoordPlayer)
                                {
                                    posBoxItem = new Vector2(posBoxItem.x, posBoxItem.y - _mainGame.Distance);
                                    box.transform.position = posBoxItem;
                                    box.CoordBox.y--;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y + 1] = 0;
                                }
                            }
                            break;
                        case State.Left:
                            posItem = new Vector2(posItem.x - _mainGame.Distance, posItem.y);
                            player.transform.position = posItem;
                            player.CoordPlayer.x--;
                            foreach (var box in _mainGame.Box)
                            {
                                var posBoxItem = box.transform.position;
                                if (box.CoordBox == player.CoordPlayer)
                                {
                                    posBoxItem = new Vector2(posBoxItem.x - _mainGame.Distance, posBoxItem.y);
                                    box.transform.position = posBoxItem;
                                    box.CoordBox.x--;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                                    _mainGame.Map[box.CoordBox.x + 1, box.CoordBox.y] = 0;
                                }
                            }
                            break;
                        case State.Right:
                            posItem = new Vector2(posItem.x + _mainGame.Distance, posItem.y);
                            player.transform.position = posItem;
                            player.CoordPlayer.x++;
                            foreach (var box in _mainGame.Box)
                            {
                                var posBoxItem = box.transform.position;
                                if (box.CoordBox == player.CoordPlayer)
                                {
                                    posBoxItem = new Vector2(posBoxItem.x + _mainGame.Distance, posBoxItem.y);
                                    box.transform.position = posBoxItem;
                                    box.CoordBox.x++;
                                    _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                                    _mainGame.Map[box.CoordBox.x - 1, box.CoordBox.y] = 0;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }


            foreach (var box in _mainGame.Box)
            {
                var posItem = box.transform.position;

                if (box.CoordBox == CoordTreadmill)
                {
                    switch (EnumState)
                    {
                        case State.Up:
                            posItem = new Vector2(posItem.x, posItem.y + _mainGame.Distance);
                            box.transform.position = posItem;
                            box.CoordBox.y++;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y - 1] = 5;
                            break;
                        case State.Down:
                            posItem = new Vector2(posItem.x, posItem.y - _mainGame.Distance);
                            box.transform.position = posItem;
                            box.CoordBox.y--;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y + 1] = 5;
                            break;
                        case State.Left:
                            posItem = new Vector2(posItem.x - _mainGame.Distance, posItem.y);
                            box.transform.position = posItem;
                            box.CoordBox.x--;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                            _mainGame.Map[box.CoordBox.x + 1, box.CoordBox.y] = 5;
                            break;
                        case State.Right:
                            posItem = new Vector2(posItem.x + _mainGame.Distance, posItem.y);
                            box.transform.position = posItem;
                            box.CoordBox.x++;
                            _mainGame.Map[box.CoordBox.x, box.CoordBox.y] = 2;
                            _mainGame.Map[box.CoordBox.x - 1, box.CoordBox.y] = 5;
                            break;
                        default:
                            break;
                    }
                }
            }
            switch (EnumState)
            {
                case State.Up:
                    SelfImage.sprite = SpriteOnOff[0];
                    break;
                case State.Down:
                    SelfImage.sprite = SpriteOnOff[1];
                    break;
                case State.Left:
                    SelfImage.sprite = SpriteOnOff[2];
                    break;
                case State.Right:
                    SelfImage.sprite = SpriteOnOff[3];
                    break;
            }
        }
        else
        {
            switch (EnumState)
            {
                case State.Up:
                    SelfImage.sprite = SpriteOnOff[4];
                    break;
                case State.Down:
                    SelfImage.sprite = SpriteOnOff[5];
                    break;
                case State.Left:
                    SelfImage.sprite = SpriteOnOff[6];
                    break;
                case State.Right:
                    SelfImage.sprite = SpriteOnOff[7];
                    break;
            }
        }
    }







}
