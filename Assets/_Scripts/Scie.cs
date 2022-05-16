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



        //if (stat == 0)
        //{
        //    coordScie.y++;
        //    posScie = new Vector2(posScie.x, posScie.y + _mainGame.Distance);
        //    transform.position = posScie;
        //    coordScie.y++;
        //}
        //else if (stat == 1)
        //{

        //    coordScie.y--;
        //}
        //else if (stat == 2)
        //{
        //    coordScie.x++;

        //}
        //else if (stat == 3)
        //{
        //    coordScie.x--;

        //}
    }
}
