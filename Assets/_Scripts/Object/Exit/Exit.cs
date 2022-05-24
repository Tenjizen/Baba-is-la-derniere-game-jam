using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    public enum State { Up, Down, Left, Right };
    public State EnumState;

    public SpriteRenderer SelfImage;
    public Sprite[] SpriteDir;

    public Vector2Int CoordExit;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }
    private void Update()
    {
        if(_mainGame.Player[0].CoordPlayer == CoordExit)
        {
            AudioManager.Instance.PlaySFXSound("snd_victory");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        switch (EnumState)
        {
            case State.Up:
                SelfImage.sprite = SpriteDir[0];
                break;
            case State.Down:
                SelfImage.sprite = SpriteDir[1];
                break;
            case State.Left:
                SelfImage.sprite = SpriteDir[2];
                break;
            case State.Right:
                SelfImage.sprite = SpriteDir[3];
                break;
        }
    }



}
[System.Serializable]
public class ExitBase
{
    public enum State { Up, Down, Left, Right };
    public State BaseState;

    public Vector2Int CoordExit;

}