using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    public bool Mirror;
    public Vector2Int coordPlayer;
    //public Vector2Int coordMirrorPlayer;
    private void Start()
    {
        Spawn();
        CoordPlayerSpawn();

    }
    void Update()
    {
        if (!_mainGame.Pause)
        {
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var pos = transform.position;

            if (_mainGame.Map[coordPlayer.x, coordPlayer.y + 1] == 1)
            {
                CheckAfterMove();
                print("mur en haut");
            }
            //else if (_mainGame.map[coordPlayer.x, coordPlayer.y + 1] == 2)
            //{

            //}
            else
            {
                pos = new Vector2(pos.x, pos.y + _mainGame.Distance);
                transform.position = pos;
                coordPlayer.y++;
                CheckAfterMove();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            var pos = transform.position;
            if (_mainGame.Map[coordPlayer.x, coordPlayer.y - 1] == 1)
            {
                CheckAfterMove();
                print("mur en bas");
            }
            //else if (_mainGame.map[coordPlayer.x, coordPlayer.y + 1] == 2)
            //{

            //}
            else
            {
                pos = new Vector2(pos.x, pos.y - _mainGame.Distance);
                transform.position = pos;
                coordPlayer.y--;
                CheckAfterMove();
            }
        }
        if (!Mirror)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                var pos = transform.position;

                if (_mainGame.Map[coordPlayer.x - 1, coordPlayer.y] == 1)
                {
                    CheckAfterMove();
                    print("mur a gauche");
                }
                else
                {
                    pos = new Vector2(pos.x - _mainGame.Distance, pos.y);
                    transform.position = pos;
                    coordPlayer.x--;
                    CheckAfterMove();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                var pos = transform.position;

                if (_mainGame.Map[coordPlayer.x + 1, coordPlayer.y] == 1)
                {
                    CheckAfterMove();
                    print("mur a droite");
                }
                else
                {
                    pos = new Vector2(pos.x + _mainGame.Distance, pos.y);
                    transform.position = pos;
                    coordPlayer.x++;
                    CheckAfterMove();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var pos = transform.position;

                if (_mainGame.Map[coordPlayer.x + 1, coordPlayer.y] == 1)
                {
                    CheckAfterMove();
                    print("mur a gauche");
                }
                else
                {
                    pos = new Vector2(pos.x + _mainGame.Distance, pos.y);
                    transform.position = pos;
                    coordPlayer.x++;
                    CheckAfterMove();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                var pos = transform.position;

                if (_mainGame.Map[coordPlayer.x - 1, coordPlayer.y] == 1)
                {
                    CheckAfterMove();
                    print("mur a droite");
                }
                else
                {
                    pos = new Vector2(pos.x - _mainGame.Distance, pos.y);
                    transform.position = pos;
                    coordPlayer.x--;
                    CheckAfterMove();
                }
            }
        }

    }
    void CheckAfterMove()
    {
        //_mainGame.Map[coordPlayer.x - 1, coordPlayer.y]
        if (_mainGame.PrefabsPlayer.Length > 1)
        {
            if (_mainGame.PrefabsPlayer[1] != null)
            {
                var posPlayerZero = _mainGame.PrefabsPlayer[0].transform.position;
                var posPlayerUno = _mainGame.PrefabsPlayer[1].transform.position;
                if (posPlayerZero.x == posPlayerUno.x - _mainGame.Distance && posPlayerZero.y == posPlayerUno.y)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



                if (_mainGame.PrefabsPlayer[1] == this.gameObject)
                {
                    if (posPlayerZero == posPlayerUno)
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
    void CoordPlayerSpawn()
    {
        var BasDroit = new Vector2Int((_mainGame.Size - 2), (_mainGame.Size - (_mainGame.Size - 1)));
        var BasGauche = new Vector2Int((_mainGame.Size - (_mainGame.Size - 1)), (_mainGame.Size - (_mainGame.Size - 1)));
        var HautDroit = new Vector2Int((_mainGame.Size - 2), (_mainGame.Size - 2));
        var HautGauche = new Vector2Int((_mainGame.Size - (_mainGame.Size - 1)), (_mainGame.Size - 2));
        if (!Mirror)
        {
            if (_mainGame.PtsSpawn == 1) //Haut gauche
                coordPlayer = HautGauche;
            else if (_mainGame.PtsSpawn == 2) //Haut droit
                coordPlayer = HautDroit;
            else if (_mainGame.PtsSpawn == 3) //Bas droit
                coordPlayer = BasDroit; //en bas a droit
            else if (_mainGame.PtsSpawn == 4) //Bas gauche
                coordPlayer = BasGauche; //en bas a gauche
            else if (_mainGame.PtsSpawn == 5) //as you want
                coordPlayer = new Vector2Int(coordPlayer.x, coordPlayer.y); //demerde toi pour le mirror
        }
        else
        {
            if (_mainGame.PtsSpawn == 1) //Haut gauche
                coordPlayer = HautDroit;
            else if (_mainGame.PtsSpawn == 2) //Haut droit
                coordPlayer = HautGauche;
            else if (_mainGame.PtsSpawn == 3) //Bas droit
                coordPlayer = BasGauche; //en bas a gauche
            else if (_mainGame.PtsSpawn == 4) //Bas gauche
                coordPlayer = BasDroit; //en bas a droit
            else if (_mainGame.PtsSpawn == 5) //as you want
                coordPlayer = new Vector2Int(coordPlayer.x, coordPlayer.y); //demerde toi pour le mirror
        }
    }
    void Spawn()
    {
        if (_mainGame.Size % 2 == 0)// map paire
        {
            var SpawnHautDroit = new Vector2(((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance,
                ((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance);
            var SpawnHautGauche = new Vector2(((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance,
                ((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance);
            var SpawnBasDroit = new Vector2(((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance,
                ((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance);
            var SpawnBasGauche = new Vector2(((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance,
                ((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance);
            if (!Mirror)
            {
                if (_mainGame.PtsSpawn == 1) //Haut gauche
                    this.transform.position = SpawnHautGauche;
                else if (_mainGame.PtsSpawn == 2) //Haut droit
                    this.transform.position = SpawnHautDroit;
                else if (_mainGame.PtsSpawn == 3) //Bas droit
                    this.transform.position = SpawnBasDroit;
                else if (_mainGame.PtsSpawn == 4) //Bas gauche
                    this.transform.position = SpawnBasGauche;
            }
            else
            {
                if (_mainGame.PtsSpawn == 1) //Haut droit
                    this.transform.position = SpawnHautDroit;
                else if (_mainGame.PtsSpawn == 2) //Haut gauche
                    this.transform.position = SpawnHautGauche;
                else if (_mainGame.PtsSpawn == 3) //Bas droit
                    this.transform.position = SpawnBasGauche;
                else if (_mainGame.PtsSpawn == 4) //Bas gauche
                    this.transform.position = SpawnBasDroit;
            }

            if (_mainGame.PtsSpawn == 5) //as you want
                this.transform.position = new Vector2((coordPlayer.x - _mainGame.Size / 2) * _mainGame.Distance,
                    (coordPlayer.y - _mainGame.Size / 2) * _mainGame.Distance);
        }
        else //map impaire
        {
            var SpawnHautDroit = new Vector2((((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f);
            var SpawnHautGauche = new Vector2((((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasDroit = new Vector2((((_mainGame.Size - _mainGame.Size + (_mainGame.Size - 2)) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasGauche = new Vector2((((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Size - _mainGame.Size + 1) - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f);
            if (!Mirror)
            {
                if (_mainGame.PtsSpawn == 1) //Haut gauche
                    this.transform.position = SpawnHautGauche;
                else if (_mainGame.PtsSpawn == 2) //Haut droit
                    this.transform.position = SpawnHautDroit;
                else if (_mainGame.PtsSpawn == 3) //Bas droit
                    this.transform.position = SpawnBasDroit;
                else if (_mainGame.PtsSpawn == 4) //Bas gauche
                    this.transform.position = SpawnBasGauche;
            }
            else
            {
                if (_mainGame.PtsSpawn == 1) //Haut droit
                    this.transform.position = SpawnHautDroit;
                else if (_mainGame.PtsSpawn == 2) //Haut gauche
                    this.transform.position = SpawnHautGauche;
                else if (_mainGame.PtsSpawn == 3) //Bas droit
                    this.transform.position = SpawnBasGauche;
                else if (_mainGame.PtsSpawn == 4) //Bas gauche
                    this.transform.position = SpawnBasDroit;
            }
            if (_mainGame.PtsSpawn == 5) //as you want
                this.transform.position = new Vector2(((coordPlayer.x - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f,
                    ((coordPlayer.y - _mainGame.Size / 2) * _mainGame.Distance) - 0.32f);
        }
    }
}
