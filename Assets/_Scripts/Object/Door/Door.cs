using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    public enum State { Left, Right, Up, Down };
    public State EnumState;

    public SpriteRenderer SelfImage;
    public Sprite[] SpriteOpenClose;


    public Vector2Int CoordDoor;

    public bool Close;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }

    private void Update()
    {
        if (!Close)
        {
            switch (EnumState)
            {
                case State.Left:
                    SelfImage.sprite = SpriteOpenClose[4];
                    break;
                case State.Right:
                    SelfImage.sprite = SpriteOpenClose[5];
                    break;
                case State.Up:
                    SelfImage.sprite = SpriteOpenClose[6];
                    break;
                case State.Down:
                    SelfImage.sprite = SpriteOpenClose[7];
                    break;
            }
        }
        else
        {
            switch (EnumState)
            {
                case State.Left:
                    SelfImage.sprite = SpriteOpenClose[0];
                    break;
                case State.Right:
                    SelfImage.sprite = SpriteOpenClose[1];
                    break;
                case State.Up:
                    SelfImage.sprite = SpriteOpenClose[2];
                    break;
                case State.Down:
                    SelfImage.sprite = SpriteOpenClose[3];
                    break;
            }
        }
        foreach (var player in _mainGame.Player)
        {
            var posItem = player.transform.position;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (player.CoordPlayer.x - 1 == CoordDoor.x && player.CoordPlayer.y == CoordDoor.y)
                {
                    if (Close)
                    {
                        //moche et repetitif faudrait revoir le code du player pour le réduire au plus simple
                        posItem = new Vector2(posItem.x + _mainGame.Distance, posItem.y);
                        player.transform.position = posItem;
                        player.CoordPlayer.x++;
                    }
                    //tant que le code du player n'est pas revu ça sert a rien
                    /*else
                    {
                        posItem = new Vector2(posItem.x - _mainGame.Distance, posItem.y);
                        player.transform.position = posItem;
                        player.CoordPlayer.x--;
                    }*/
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (player.CoordPlayer.x + 1 == CoordDoor.x && player.CoordPlayer.y == CoordDoor.y)
                {
                    if (Close)
                    {
                        posItem = new Vector2(posItem.x - _mainGame.Distance, posItem.y);
                        player.transform.position = posItem;
                        player.CoordPlayer.x--;
                    }
                    /*else
                    {
                        posItem = new Vector2(posItem.x + _mainGame.Distance, posItem.y);
                        player.transform.position = posItem;
                        player.CoordPlayer.x++;
                    }*/
                }
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                if (player.CoordPlayer.y + 1 == CoordDoor.y && player.CoordPlayer.x == CoordDoor.x)
                {
                    if (Close)
                    {
                        posItem = new Vector2(posItem.x, posItem.y - _mainGame.Distance);
                        player.transform.position = posItem;
                        player.CoordPlayer.y--;
                    }
                    /*else
                    {
                        posItem = new Vector2(posItem.x , posItem.y + _mainGame.Distance);
                        player.transform.position = posItem;
                        player.CoordPlayer.y++;
                    }*/
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (player.CoordPlayer.y - 1 == CoordDoor.y && player.CoordPlayer.x == CoordDoor.x)
                {
                    if (Close)
                    {
                        posItem = new Vector2(posItem.x, posItem.y + _mainGame.Distance);
                        player.transform.position = posItem;
                        player.CoordPlayer.y++;
                    }
                    /*else
                    {
                        posItem = new Vector2(posItem.x, posItem.y - _mainGame.Distance);
                        player.transform.position = posItem;
                        player.CoordPlayer.y--;
                    }*/
                }
            }
        }
    }
}
