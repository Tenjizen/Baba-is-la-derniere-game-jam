using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;


    public SpriteRenderer SelfImage;


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
            SelfImage.color = new Color(0, 0, 0, 25);
        }
        else
        {
            SelfImage.color = new Color(255, 255, 255, 100);
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
                        print("québlo");
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
                        print("québlo");
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
                        print("québlo");
                        posItem = new Vector2(posItem.x , posItem.y - _mainGame.Distance);
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
                        print("québlo");
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
