using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] MainGame _mainGame;
    public bool Mirror;
    public Vector2Int CoordPlayer;
    public Vector2Int oldPos;
    public SpriteRenderer _spriteRenderer;
    public Animator Animator;
    private Vector2 _input;

    private void Start()
    {
        _mainGame = FindObjectOfType<MainGame>();
        Spawn();
        CoordPlayerSpawn();
    }
    void Update()
    {
        if (!_mainGame.Pause)
        {
            MovePlayer();
        }
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        if (_input.x == -1)
            _spriteRenderer.flipX = true;
        else if (_input.x == 1)
            _spriteRenderer.flipX = false;
        else if (_input.y == 1)
            _spriteRenderer.flipX = false;
        else if (_input.y == -1)
            _spriteRenderer.flipX = false;

        if (_input != Vector2.zero)
        {
            Animator.SetFloat("X", _input.x);
            Animator.SetFloat("Y", _input.y);
        }


    }
    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var posPlayer = transform.position;

            if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y + 1] == 1)
            {
                CheckAfterMove();
            }
            else if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y + 1] == 2)
            {
                CaisseUp();
            }
            else
            {
                oldPos = CoordPlayer;
                posPlayer = new Vector2(posPlayer.x, posPlayer.y + _mainGame.Distance);
                transform.position = posPlayer;
                CoordPlayer.y++;
                CheckAfterMove();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

            var pos = transform.position;
            if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y - 1] == 1)
            {
                CheckAfterMove();
            }
            else if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y - 1] == 2)
            {
                CaisseDown();
            }
            else
            {
                oldPos = CoordPlayer;
                pos = new Vector2(pos.x, pos.y - _mainGame.Distance);
                transform.position = pos;
                CoordPlayer.y--;
                CheckAfterMove();
            }
        }
        if (!Mirror)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                var pos = transform.position;

                if (_mainGame.Map[CoordPlayer.x - 1, CoordPlayer.y] == 1)
                {
                    CheckAfterMove();
                }
                else if (_mainGame.Map[CoordPlayer.x - 1, CoordPlayer.y] == 2)
                {
                    CaisseLeft();
                }
                else
                {
                    oldPos = CoordPlayer;
                    pos = new Vector2(pos.x - _mainGame.Distance, pos.y);
                    transform.position = pos;
                    CoordPlayer.x--;
                    CheckAfterMove();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                var pos = transform.position;

                if (_mainGame.Map[CoordPlayer.x + 1, CoordPlayer.y] == 1)
                {
                    CheckAfterMove();
                }
                else if (_mainGame.Map[CoordPlayer.x + 1, CoordPlayer.y] == 2)
                {
                    CaisseRight();
                }
                else
                {
                    oldPos = CoordPlayer;
                    pos = new Vector2(pos.x + _mainGame.Distance, pos.y);
                    transform.position = pos;
                    CoordPlayer.x++;
                    CheckAfterMove();

                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var pos = transform.position;

                if (_mainGame.Map[CoordPlayer.x + 1, CoordPlayer.y] == 1)
                {
                    CheckAfterMove();
                }
                else if (_mainGame.Map[CoordPlayer.x + 1, CoordPlayer.y] == 2)
                {
                    CaisseRight();
                }
                else
                {
                    oldPos = CoordPlayer;
                    pos = new Vector2(pos.x + _mainGame.Distance, pos.y);
                    transform.position = pos;
                    CoordPlayer.x++;
                    CheckAfterMove();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                var pos = transform.position;

                if (_mainGame.Map[CoordPlayer.x - 1, CoordPlayer.y] == 1/*||
                    _mainGame.Map[CoordPlayer.x - 1, CoordPlayer.y] == 6*/)
                {
                    CheckAfterMove();
                }
                else if (_mainGame.Map[CoordPlayer.x - 1, CoordPlayer.y] == 2)
                {

                    CaisseLeft();
                }
                else
                {
                    oldPos = CoordPlayer;
                    pos = new Vector2(pos.x - _mainGame.Distance, pos.y);
                    transform.position = pos;
                    CoordPlayer.x--;
                    CheckAfterMove();
                }
            }
        }

    }

    void CheckAfterMove()
    {
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
        if (_mainGame.Saw.Count > 0)
        {
            for (int i = 0; i < _mainGame.Saw.Count; i++)
            {
                for (int y = 0; y < _mainGame.Player.Count; y++)
                {
                    if (_mainGame.Saw[i].CoordSaw == _mainGame.Player[y].CoordPlayer)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    if (_mainGame.Player[y].oldPos == _mainGame.Saw[i].CoordSaw && _mainGame.Player[y].CoordPlayer == _mainGame.Saw[i].OldCoordSaw)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }
    }
    void CoordPlayerSpawn()
    {
        var BasDroit = new Vector2Int((_mainGame.Wight - 2), (_mainGame.Hight - (_mainGame.Hight - 1)));
        var BasGauche = new Vector2Int((_mainGame.Wight - (_mainGame.Wight - 1)), (_mainGame.Hight - (_mainGame.Hight - 1)));
        var HautDroit = new Vector2Int((_mainGame.Wight - 2), (_mainGame.Hight - 2));
        var HautGauche = new Vector2Int((_mainGame.Wight - (_mainGame.Wight - 1)), (_mainGame.Hight - 2));
        if (!Mirror)
        {
            if (_mainGame.PtsSpawn == 1) //Haut gauche
                CoordPlayer = HautGauche;
            else if (_mainGame.PtsSpawn == 2) //Haut droit
                CoordPlayer = HautDroit;
            else if (_mainGame.PtsSpawn == 3) //Bas droit
                CoordPlayer = BasDroit; //en bas a droit
            else if (_mainGame.PtsSpawn == 4) //Bas gauche
                CoordPlayer = BasGauche; //en bas a gauche
            else if (_mainGame.PtsSpawn == 5) //as you want
                CoordPlayer = new Vector2Int(CoordPlayer.x, CoordPlayer.y); //demerde toi pour le mirror
        }
        else
        {
            if (_mainGame.PtsSpawn == 1) //Haut gauche
                CoordPlayer = HautDroit;
            else if (_mainGame.PtsSpawn == 2) //Haut droit
                CoordPlayer = HautGauche;
            else if (_mainGame.PtsSpawn == 3) //Bas droit
                CoordPlayer = BasGauche; //en bas a gauche
            else if (_mainGame.PtsSpawn == 4) //Bas gauche
                CoordPlayer = BasDroit; //en bas a droit
            else if (_mainGame.PtsSpawn == 5) //as you want
                CoordPlayer = new Vector2Int(CoordPlayer.x, CoordPlayer.y); //demerde toi pour le mirror
        }
    }
    void Spawn()
    {
        if (_mainGame.Wight % 2 == 0 && _mainGame.Hight % 2 == 0)// map paire
        {
            var SpawnHautDroit = new Vector2(((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance,
                ((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnHautGauche = new Vector2(((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance,
                ((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnBasDroit = new Vector2(((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance,
                ((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnBasGauche = new Vector2(((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance,
                ((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance);
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
                this.transform.position = new Vector2((CoordPlayer.x - _mainGame.Wight / 2) * _mainGame.Distance,
                    (CoordPlayer.y - _mainGame.Hight / 2) * _mainGame.Distance);
        }
        else if (_mainGame.Wight % 2 != 0 && _mainGame.Hight % 2 == 0)//Wight impaire
        {
            var SpawnHautDroit = new Vector2((((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                ((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnHautGauche = new Vector2((((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                ((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnBasDroit = new Vector2((((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                ((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance);
            var SpawnBasGauche = new Vector2((((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                ((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance);
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
                this.transform.position = new Vector2(((CoordPlayer.x - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                    (CoordPlayer.y - _mainGame.Hight / 2) * _mainGame.Distance);
        }
        else if (_mainGame.Wight % 2 == 0 && _mainGame.Hight % 2 != 0)//Hight impair
        {
            var SpawnHautDroit = new Vector2(((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance,
                (((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnHautGauche = new Vector2(((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance,
                (((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasDroit = new Vector2(((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance,
                (((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasGauche = new Vector2(((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance,
                (((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
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
                this.transform.position = new Vector2((CoordPlayer.x - _mainGame.Wight / 2) * _mainGame.Distance,
                    ((CoordPlayer.y - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
        }
        else //map impaire
        {
            var SpawnHautDroit = new Vector2((((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnHautGauche = new Vector2((((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Hight - _mainGame.Hight + (_mainGame.Hight - 2)) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasDroit = new Vector2((((_mainGame.Wight - _mainGame.Wight + (_mainGame.Wight - 2)) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
            var SpawnBasGauche = new Vector2((((_mainGame.Wight - _mainGame.Wight + 1) - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                (((_mainGame.Hight - _mainGame.Hight + 1) - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
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
                this.transform.position = new Vector2(((CoordPlayer.x - _mainGame.Wight / 2) * _mainGame.Distance) - 0.32f,
                    ((CoordPlayer.y - _mainGame.Hight / 2) * _mainGame.Distance) - 0.32f);
        }
    }
    public void CaisseUp()
    {
        if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y + 2] == 6)
        {
            foreach (var item in _mainGame.Door)
            {
                if (item.CoordDoor.x == CoordPlayer.x && item.CoordDoor.y == CoordPlayer.y + 2)
                {
                    if (!item.Close) { MoveBoxUp(); }
                }
            }
        }
        else if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y + 2] == 5)
        {
            MoveBoxUp();
        }
        else if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y + 2] != 0)
        {
        }
        else
        {
            MoveBoxUp();
        }
    }
    public void CaisseDown()
    {
        var posPlayer = transform.position;
        var caisse = _mainGame.Box;
        if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y - 2] == 5)
        {
            MoveBoxDown();
        }
        else if (_mainGame.Map[CoordPlayer.x, CoordPlayer.y - 2] != 0)
        {
        }
        else
        {
            MoveBoxDown();
        }
    }
    public void CaisseLeft()
    {
        if (_mainGame.Map[CoordPlayer.x - 2, CoordPlayer.y] == 5)
        {
            MoveBoxLeft();
        }
        else if (_mainGame.Map[CoordPlayer.x - 2, CoordPlayer.y] != 0)
        {
        }
        else
        {
            MoveBoxLeft();
        }

    }
    public void CaisseRight()
    {
        if (_mainGame.Map[CoordPlayer.x + 2, CoordPlayer.y] == 5)
        {
            MoveBoxRight();
        }
        else if (_mainGame.Map[CoordPlayer.x + 2, CoordPlayer.y] != 0)
        {
        }
        else
        {
            MoveBoxRight();
        }
    }
    public void MoveBoxUp()
    {
        var posPlayer = transform.position;
        var caisse = _mainGame.Box;
        for (int i = 0; i < _mainGame.Box.Count; i++)
        {
            if (caisse[i].CoordBox.x == CoordPlayer.x && caisse[i].CoordBox.y == CoordPlayer.y + 1)
            {
                caisse[i].CoordBox.y++;
                _mainGame.Box[i].transform.position = new Vector2(caisse[i].transform.position.x, caisse[i].transform.position.y + _mainGame.Distance);
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y] = 2;
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y - 1] = 0;
                break;
            }
        }
        posPlayer = new Vector2(posPlayer.x, posPlayer.y + _mainGame.Distance);
        transform.position = posPlayer;
        CoordPlayer.y++;
    }
    public void MoveBoxDown()
    {
        var posPlayer = transform.position;
        var caisse = _mainGame.Box;

        for (int i = 0; i < _mainGame.Box.Count; i++)
        {
            if (caisse[i].CoordBox.x == CoordPlayer.x && caisse[i].CoordBox.y == CoordPlayer.y - 1)
            {
                caisse[i].CoordBox.y--;
                _mainGame.Box[i].transform.position = new Vector2(caisse[i].transform.position.x, caisse[i].transform.position.y - _mainGame.Distance);
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y] = 2;
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y + 1] = 0;
                break;
            }
        }
        posPlayer = new Vector2(posPlayer.x, posPlayer.y - _mainGame.Distance);
        transform.position = posPlayer;
        CoordPlayer.y--;
    }
    public void MoveBoxLeft()
    {
        var posPlayer = transform.position;
        var caisse = _mainGame.Box;

        for (int i = 0; i < _mainGame.Box.Count; i++)
        {
            if (caisse[i].CoordBox.x == CoordPlayer.x - 1 && caisse[i].CoordBox.y == CoordPlayer.y)
            {
                caisse[i].CoordBox.x--;
                _mainGame.Box[i].transform.position = new Vector2(caisse[i].transform.position.x - _mainGame.Distance, caisse[i].transform.position.y);
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y] = 2;
                _mainGame.Map[caisse[i].CoordBox.x + 1, caisse[i].CoordBox.y] = 0;
                break;
            }
        }
        posPlayer = new Vector2(posPlayer.x - _mainGame.Distance, posPlayer.y);
        transform.position = posPlayer;
        CoordPlayer.x--;
    }
    public void MoveBoxRight()
    {
        var posPlayer = transform.position;
        var caisse = _mainGame.Box;

        for (int i = 0; i < _mainGame.Box.Count; i++)
        {
            if (caisse[i].CoordBox.x == CoordPlayer.x + 1 && caisse[i].CoordBox.y == CoordPlayer.y)
            {
                caisse[i].CoordBox.x++;
                _mainGame.Box[i].transform.position = new Vector2(caisse[i].transform.position.x + _mainGame.Distance, caisse[i].transform.position.y);
                _mainGame.Map[caisse[i].CoordBox.x - 1, caisse[i].CoordBox.y] = 0;
                _mainGame.Map[caisse[i].CoordBox.x, caisse[i].CoordBox.y] = 2;
                break;
            }
        }
        posPlayer = new Vector2(posPlayer.x + _mainGame.Distance, posPlayer.y);
        transform.position = posPlayer;
        CoordPlayer.x++;
    }


}
