using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private GameObject _player => _settableSkin.Current;

    [SerializeField]
    private GameObject _deadZone;

    [SerializeField]
    private Canvas _buttonMove;

    private Spawner _spawner;

    private UpdateVelocityGame _updateVelocityGame;

    private SettableSkin _settableSkin;

    private Health _health;

    private Energy _energy;

    private Score _score;
    public StepByStepAnimation pigANim;
    public bool IsFly { get; private set; } = false;

    [Inject]
    public void Construct(Health health, Energy energy, Score score, UpdateVelocityGame updateVelocityGame, SettableSkin settableSkin, SpawnerConfig spawnerConfig)
    {
        _settableSkin = settableSkin;

        _score = score;

        _updateVelocityGame = updateVelocityGame;

        _health = health;

        _energy = energy;

        _spawner = new Spawner(spawnerConfig, transform, _score);
    }

    public void SetFly(bool value)
    {
        IsFly = value;
    }

    public void SetGame(bool value)
    {
        GameState.Set(value);
    }

    private void Awake()
    {
        ActivateGameObjects(false);

        _health.OnZeroing += _spawner.Stop;

        _health.OnZeroing += _updateVelocityGame.Stop;

        _health.OnZeroing += _updateVelocityGame.Reset;
    }

    private void OnDisable()
    {
        _health.OnZeroing -= _spawner.Stop;

        _health.OnZeroing -= _updateVelocityGame.Stop;

        _health.OnZeroing -= _updateVelocityGame.Reset;
    }

    public void StartG()
    {
        _player.transform.SetParent(null);

        if (IsFly == true)
            _player.GetComponent<SaverStartPosition>().Set();

        StartGame();
    }

    private void ActivateGameObjects(bool value)
    {
        _deadZone.SetActive(value);

        _buttonMove.enabled = value;
    }

    public void SpawbGolube()
    {
        _spawner.Stop();

        _updateVelocityGame.Reset();

        _updateVelocityGame.Stop();

        ActivateGameObjects(false);

        _player.GetComponent<MovingPlayer>().enabled = false;

        _settableSkin.SetLast();

        _spawner.UnloadAll();

        _score.Reset();
    }

    private void StartGame()
    {
        _player.GetComponent<MovingPlayer>().enabled = true;

        _updateVelocityGame.Reset();

        _updateVelocityGame.Start();

        _score.Start();

        _spawner.Start();

        _deadZone.SetActive(true);

        _buttonMove.enabled = true;

        Debug.Log("Bootstrap " + Time.timeScale);
    }

    public void RestartGame()
    {
        _health.Increase(_health.Max);

        _energy.Increase(_energy.Max);

        ActivateGameObjects(false);

        //PoolAssetLoader.UnloadAll();

        _spawner.UnloadAll();

        _score.Reset();

        //_player.Set();

        StartGame();
    }
}