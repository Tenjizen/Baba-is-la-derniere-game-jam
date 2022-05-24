using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Electricity : MonoBehaviour
{
    public enum State { Left, Right, Up, Down, Middle };
    public State EnumState;

    [SerializeField] MainGame _mainGame;

    public SpriteRenderer SelfImage;
    public Sprite[] SpriteOpen;
    public Sprite[] SpriteClose;

    public Vector2Int CoordElectricity;

    public bool Open;
    private bool Horizontal;

    private void Start()
    {
        Horizontal = true;
        _mainGame = FindObjectOfType<MainGame>();
    }
    private void Update()
    {
        if (Open)
        {

            SelfImage.enabled = true;
            switch (EnumState)
            {
                case State.Left:
                    if (Horizontal)
                        SelfImage.sprite = SpriteOpen[0];
                    else
                        SelfImage.sprite = SpriteOpen[1];
                    break;
                case State.Right:
                    if (Horizontal)
                        SelfImage.sprite = SpriteOpen[2];
                    else
                        SelfImage.sprite = SpriteOpen[3];
                    break;
                case State.Up:
                    if (Horizontal)
                        SelfImage.sprite = SpriteOpen[4];
                    else
                        SelfImage.sprite = SpriteOpen[5];
                    break;
                case State.Down:
                    if (Horizontal)
                        SelfImage.sprite = SpriteOpen[6];
                    else
                        SelfImage.sprite = SpriteOpen[7];
                    break;
                case State.Middle:
                    SelfImage.enabled = false;
                    break;
            }
        }
        else
        {
            switch (EnumState)
            {
                case State.Left:
                    if (Horizontal)
                        SelfImage.sprite = SpriteClose[0];
                    else
                        SelfImage.sprite = SpriteClose[1];
                    break;
                case State.Right:
                    if (Horizontal)
                        SelfImage.sprite = SpriteClose[2];
                    else
                        SelfImage.sprite = SpriteClose[3];
                    break;
                case State.Up:
                    if (Horizontal)
                        SelfImage.sprite = SpriteClose[4];
                    else
                        SelfImage.sprite = SpriteClose[5];
                    break;
                case State.Down:
                    if (Horizontal)
                        SelfImage.sprite = SpriteClose[6];
                    else
                        SelfImage.sprite = SpriteClose[7];
                    break;
                case State.Middle:
                    if (Horizontal)
                        SelfImage.sprite = SpriteClose[8];
                    else
                        SelfImage.sprite = SpriteClose[9];
                    break;
            }
        }
        foreach (var player in _mainGame.Player)
        {
            if (player.CoordPlayer == CoordElectricity && !Open)
            {
                AudioManager.Instance.PlaySFXSound("snd_electric_death");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
