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

       for (int i = 0; i < _mainGame.List.Count; i++)
        {
            coordScie = _mainGame.List[i].coordBaseScie;

            targetUp = _mainGame.List[i].targetBaseUp;
            targetDown = _mainGame.List[i].targetBaseDown;
            targetRight = _mainGame.List[i].targetBaseRight;
            targetLeft = _mainGame.List[i].targetBaseLeft;

            var jhgjd = (int)_mainGame.List[i].stateBase;
            state = 0;
            while (jhgjd != (int)state)
            {
                state += 1;
            }
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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
                    posScie = new Vector2(posScie.x, posScie.y + _mainGame.Distance);
                    transform.position = posScie;
                    coordScie.y++;
                    if (coordScie.y == targetUp)
                        state = State.Down;
                }
                break;
            case State.Down:
                if (coordScie.y > targetDown)
                {
                    posScie = new Vector2(posScie.x, posScie.y - _mainGame.Distance);
                    transform.position = posScie;
                    coordScie.y--;
                    if (coordScie.y == targetDown)
                        state = State.Up;
                }
                break;
            case State.Left:
                if (coordScie.x > targetLeft)
                {
                    posScie = new Vector2(posScie.x - _mainGame.Distance, posScie.y);
                    transform.position = posScie;
                    coordScie.x--;
                    if (coordScie.x == targetLeft)
                        state = State.Right;
                }
                break;
            case State.Right:
                if (coordScie.x < targetRight)
                {
                    posScie = new Vector2(posScie.x + _mainGame.Distance, posScie.y);
                    transform.position = posScie;
                    coordScie.x++;
                    if (coordScie.x == targetRight)
                        state = State.Left;
                }
                break;
            default:
                break;
        }

    }
}
