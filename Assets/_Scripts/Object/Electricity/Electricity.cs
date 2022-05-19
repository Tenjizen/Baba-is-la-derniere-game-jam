using UnityEngine;
using UnityEngine.SceneManagement;

public class Electricity : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public SpriteRenderer SelfImage;


    public Vector2Int CoordElectricity;
    public bool Open;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }


    private void Update()
    {
        if (Open)
        {
            SelfImage.color = new Color(0, 0, 0, 25);
        }
        else
        {
            SelfImage.color = new Color(255, 255, 255, 100);
        }
        foreach (var player in _mainGame.Player)
        {
            if (player.CoordPlayer == CoordElectricity && !Open)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
