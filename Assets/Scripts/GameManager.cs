using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Frogger _frogger;
    private Home[] _homes;

    private int _score;
    private int _lives;

    private int _time;

    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _timeText;

    private void Awake()
    {
        _frogger = FindObjectOfType<Frogger>();
        _homes = FindObjectsOfType<Home>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        _gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(3);
        NewLevel();
    }

    private void NewLevel()
    {
        for (int i = 0; i < _homes.Length; i++)
        {
            _homes[i].enabled = false;
        }

        Respawn();
    }

    private void Respawn()
    {
        _frogger.Respawn();

        // ...
        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }

    private IEnumerator Timer(int duration)
    {
        _time = duration;

        while (_time > 0)
        {
            yield return new WaitForSeconds(1);

            _time--;
            _timeText.text = _time.ToString();
        }

        _frogger.Death();
    }

    private void SetScore(int score)
    {
        this._score = score;
        // ...ui
        _scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this._lives = lives;
        // ...ui
        _livesText.text = lives.ToString();
    }

    public void HomeOccupied()
    {
        _frogger.gameObject.SetActive(false);

        int bonusPoints = _time * 20;
        SetScore(_score + +bonusPoints + 50);

        if (IsLevelCleared())
        {
            SetLives(_lives + 1);
            SetScore(_score + 1000);
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(Respawn), 1f);
        }
    }

    public void AdvancedRow()
    {
        SetScore(_score + 10);
    }

    public void Died()
    {
        SetLives(_lives - 1);

        if (_lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _frogger.gameObject.SetActive(false);
        _gameOverMenu.SetActive(true);
        // ...
        StopAllCoroutines();
        StartCoroutine(PlayAgain());
    }

    private IEnumerator PlayAgain()
    {
        bool playAgain = false;

        while (!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }

            yield return null;
        }

        NewGame();
    }

    private bool IsLevelCleared()
    {
        for (int i = 0; i < _homes.Length; i++)
        {
            if (!_homes[i].enabled)
            {
                return false;
            }
        }

        return true;
    }
}
