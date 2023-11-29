using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    private float _timeBeforeGameOver = 1;
    private float _gameOverTimer = 0;
    private bool _isGameOverTimerStarted = false;

    [SerializeField]
    private WinningPanel _winningPanel;

    [SerializeField]
    private List<Unit> _units;

    private int _enemiesCount = 0;
    private bool _isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Unit unit in _units)
        {
            unit.OnUnitDestroyed.AddListener(OnUnitDestroyed);
            if (unit.Side == 1)
            {
                _enemiesCount++;
            }
        }
    }
    private void Update()
    {
        if (_isGameOverTimerStarted)
        {
            _gameOverTimer -= Time.deltaTime;
            if (_gameOverTimer < 0)
            {
                DetermineWinner();
            }
        }
    }
    private void OnUnitDestroyed(Unit unit)
    {
        unit.OnUnitDestroyed.RemoveListener(OnUnitDestroyed);

        if (unit.Side == 1)
        {
            _enemiesCount--;
        }
        else
        {
            _isPlayerDead = true;
        }
        CheckGameOverConditions();
    }
    private void CheckGameOverConditions()
    {
        if (_isPlayerDead || _enemiesCount <= 0)
        {
            _isGameOverTimerStarted = true;
        }
    }
    private void DetermineWinner()
    {
        string message = "";
        if (_units.Count == 0)
        {
            message = "It is a draw!";
            Debug.Log("Draw");
        }
        else if(_enemiesCount <= 0)
        {
            message = "You win!";
        }
        else if(_isPlayerDead)
        {
            message = "You lose!";
        }
        _isGameOverTimerStarted = false;
        _winningPanel.Show(message, Restart);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
