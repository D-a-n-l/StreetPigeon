using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private GameObject _player => _settableSkin.Current;

    [SerializeField]
    private GameObject _topDeadZone;

    [SerializeField]
    private Canvas _buttonMove;

    private LoopSpawnObject _loopSpawnObject;

    private UpdateVelocityGame _updateVelocityGame;

    private SettableSkin _settableSkin;

    private Health _health;

    private Energy _energy;

    private Score _score;

    private bool isFly = false;

    [Inject]
    public void Construct(Health health, Energy energy, Score score, UpdateVelocityGame updateVelocityGame, SettableSkin settableSkin, LoopSpawnConfig loopSpawnConfig)
    {
        _settableSkin = settableSkin;

        _score = score;

        _updateVelocityGame = updateVelocityGame;

        _health = health;

        _energy = energy;

        _loopSpawnObject = new LoopSpawnObject(loopSpawnConfig, transform, _score);
    }

    public void SetFly()
    {
        isFly = true;
    }

    private void Awake()
    {
        ActivateGameObjects(false);

        _health.OnZeroing += _updateVelocityGame.Stop;

        _health.OnZeroing += _updateVelocityGame.Reset;
    }

    private void OnDisable()
    {
        _health.OnZeroing -= _updateVelocityGame.Stop;

        _health.OnZeroing -= _updateVelocityGame.Reset;
    }

    public void StartG()
    {
        _player.transform.SetParent(null);

        if (isFly == true)
            _player.GetComponent<SaverStartPosition>().Set();

        StartGame();
    }

    private void ActivateGameObjects(bool value)
    {
        _topDeadZone.SetActive(value);

        _buttonMove.enabled = value;
    }

    private void StartGame()
    {
        _player.GetComponent<MovingPlayer>().enabled = true;

        _updateVelocityGame.Reset();

        _updateVelocityGame.Start();

        _score.Start();

        _loopSpawnObject.Start();

        _topDeadZone.SetActive(true);

        _buttonMove.enabled = true;
    }

    public void RestartGame()
    {
        _health.Increase(_health.Max);

        _energy.Increase(_energy.Max);

        ActivateGameObjects(false);

        LocalAssetLoader.UnloadAll();

        _score.Reset();

        //_player.Set();

        StartGame();
    }
}