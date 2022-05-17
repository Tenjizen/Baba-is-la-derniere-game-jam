using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scie : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int coordScie;


    public int targetUp;
    public int targetDown;
    public int targetRight;
    public int targetLeft;

    public enum State { Up, Down, Left, Right };
    public State state;

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
        switch (state)
        {
            case State.Up:
                if (coordScie.y < targetUp)
                {
                    if (_mainGame.Map[coordScie.x, coordScie.y + 1] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        posScie = new Vector2(posScie.x, posScie.y + _mainGame.Distance);
                        transform.position = posScie;
                        coordScie.y++;
                        _mainGame.Map[coordScie.x, coordScie.y] = 3;
                        _mainGame.Map[coordScie.x, coordScie.y - 1] = 0;
                        if (coordScie.y == targetUp)
                            state = State.Down;
                        else if (_mainGame.Map[coordScie.x, coordScie.y + 1] == 1 ||
                            _mainGame.Map[coordScie.x, coordScie.y + 1] == 2)
                            state = State.Down;
                    }
                }
                else
                {
                    state = State.Down;
                }

                break;
            case State.Down:

                if (coordScie.y > targetDown)
                {
                    if (_mainGame.Map[coordScie.x, coordScie.y - 1] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        posScie = new Vector2(posScie.x, posScie.y - _mainGame.Distance);
                        transform.position = posScie;
                        coordScie.y--;
                        _mainGame.Map[coordScie.x, coordScie.y] = 3;
                        _mainGame.Map[coordScie.x, coordScie.y + 1] = 0;
                        if (coordScie.y == targetDown)
                            state = State.Up;
                        else if (_mainGame.Map[coordScie.x, coordScie.y - 1] == 1 ||
                            _mainGame.Map[coordScie.x, coordScie.y - 1] == 2)
                            state = State.Up;
                    }
                }
                else
                {
                    state = State.Up;
                }

                break;
            case State.Left:
                if (coordScie.x > targetLeft)
                {
                    if (_mainGame.Map[coordScie.x - 1, coordScie.y] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        posScie = new Vector2(posScie.x - _mainGame.Distance, posScie.y);
                        transform.position = posScie;
                        coordScie.x--;
                        _mainGame.Map[coordScie.x, coordScie.y] = 3;
                        _mainGame.Map[coordScie.x + 1, coordScie.y] = 0;
                        if (coordScie.x == targetLeft)
                            state = State.Right;
                        else if (_mainGame.Map[coordScie.x - 1, coordScie.y] == 1 ||
                                _mainGame.Map[coordScie.x - 1, coordScie.y] == 2)
                            state = State.Right;
                    }
                }
                else
                {
                    state = State.Right;
                }
                break;
            case State.Right:
                if (coordScie.x < targetRight)
                {
                    if (_mainGame.Map[coordScie.x + 1, coordScie.y] == 2)
                    {
                        print("bloquer par caisse");
                    }
                    else
                    {
                        posScie = new Vector2(posScie.x + _mainGame.Distance, posScie.y);
                        transform.position = posScie;
                        coordScie.x++;
                        _mainGame.Map[coordScie.x, coordScie.y] = 3;
                        _mainGame.Map[coordScie.x - 1, coordScie.y] = 0;
                        if (coordScie.x == targetRight)
                            state = State.Left;
                        else if (_mainGame.Map[coordScie.x + 1, coordScie.y] == 1 ||
                                _mainGame.Map[coordScie.x + 1, coordScie.y] == 2)
                            state = State.Left;
                    }
                }
                else
                {
                    state = State.Left;
                }
                break;
            default:
                break;
        }

    }
}
