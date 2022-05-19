using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class Saw : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int CoordSaw;
    public Vector2Int OldCoordSaw;


    public int TargetUp;
    public int TargetDown;
    public int TargetRight;
    public int TargetLeft;

    public enum State { Up, Down, Left, Right };
    public State EnumState;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D))
        {
            MoveScie();
        }
    }

    void MoveScie()
    {
        var posScie = transform.position;
        switch (EnumState)
        {
            case State.Up:
                if (CoordSaw.y < TargetUp)
                {
                    if (_mainGame.Map[CoordSaw.x, CoordSaw.y + 1] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        OldCoordSaw = CoordSaw;

                        posScie = new Vector2(posScie.x, posScie.y + _mainGame.Distance);
                        transform.position = posScie;
                        CoordSaw.y++;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y] = 3;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y - 1] = 0;
                        if (CoordSaw.y == TargetUp)
                            EnumState = State.Down;
                        else if (_mainGame.Map[CoordSaw.x, CoordSaw.y + 1] == 1 ||
                            _mainGame.Map[CoordSaw.x, CoordSaw.y + 1] == 2)
                            EnumState = State.Down;
                    }
                }
                else
                {
                    EnumState = State.Down;
                }

                break;
            case State.Down:

                if (CoordSaw.y > TargetDown)
                {
                    if (_mainGame.Map[CoordSaw.x, CoordSaw.y - 1] == 2)
                    {
                        print("bloquer par caisse");
                        EnumState = State.Up;
                    }
                    else
                    {
                        OldCoordSaw = CoordSaw;
                        posScie = new Vector2(posScie.x, posScie.y - _mainGame.Distance);
                        transform.position = posScie;
                        CoordSaw.y--;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y] = 3;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y + 1] = 0;
                        if (CoordSaw.y == TargetDown)
                            EnumState = State.Up;
                        else if (_mainGame.Map[CoordSaw.x, CoordSaw.y - 1] == 1 ||
                            _mainGame.Map[CoordSaw.x, CoordSaw.y - 1] == 2)
                            EnumState = State.Up;
                    }
                }
                else
                {
                    EnumState = State.Up;
                }

                break;
            case State.Left:
                if (CoordSaw.x > TargetLeft)
                {
                    if (_mainGame.Map[CoordSaw.x - 1, CoordSaw.y] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        OldCoordSaw = CoordSaw;
                        posScie = new Vector2(posScie.x - _mainGame.Distance, posScie.y);
                        transform.position = posScie;
                        CoordSaw.x--;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y] = 3;
                        _mainGame.Map[CoordSaw.x + 1, CoordSaw.y] = 0;
                        if (CoordSaw.x == TargetLeft)
                            EnumState = State.Right;
                        else if (_mainGame.Map[CoordSaw.x - 1, CoordSaw.y] == 1 ||
                                _mainGame.Map[CoordSaw.x - 1, CoordSaw.y] == 2)
                            EnumState = State.Right;
                    }
                }
                else
                {
                    EnumState = State.Right;
                }
                break;
            case State.Right:
                if (CoordSaw.x < TargetRight)
                {
                    if (_mainGame.Map[CoordSaw.x + 1, CoordSaw.y] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        OldCoordSaw = CoordSaw;
                        posScie = new Vector2(posScie.x + _mainGame.Distance, posScie.y);
                        transform.position = posScie;
                        CoordSaw.x++;
                        _mainGame.Map[CoordSaw.x, CoordSaw.y] = 3;
                        _mainGame.Map[CoordSaw.x - 1, CoordSaw.y] = 0;
                        if (CoordSaw.x == TargetRight)
                            EnumState = State.Left;
                        else if (_mainGame.Map[CoordSaw.x + 1, CoordSaw.y] == 1 ||
                                _mainGame.Map[CoordSaw.x + 1, CoordSaw.y] == 2)
                            EnumState = State.Left;
                    }
                }
                else
                {
                    EnumState = State.Left;
                }
                break;
            default:
                break;
        }
        
    }
    
}
