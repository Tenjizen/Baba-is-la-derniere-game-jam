using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;

    public Vector2Int CoordExit;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
    }
    private void Update()
    {
        if(_mainGame.Player[0].CoordPlayer == CoordExit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }



}
