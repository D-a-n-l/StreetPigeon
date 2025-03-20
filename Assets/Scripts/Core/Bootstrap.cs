using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [field: SerializeField]
    public StepByStepAnimation ButtonStart { get; private set; }

    [SerializeField]
    private GameObject _deadZone;

    [SerializeField]
    private Canvas _buttonMove;

    private Spawner _spawner;

    private RefrashableTimeScaleFromScore _updateVelocityGame;

    private SettableSkin _settableSkin;

    private Health _health;

    private Energy _energy;

    private Score _score;

    private GameObject _player => _settableSkin.Current;

    private bool _isFly = false;

    [Inject]
    public void Construct(Health health, Energy energy, Score score, RefrashableTimeScaleFromScore updateVelocityGame, SettableSkin settableSkin, SpawnerConfig spawnerConfig)
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
        _isFly = value;
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

        _health.OnZeroing += _score.Reset;

        _health.OnZeroing += OffPLayer;
    }

    private void OnDisable()
    {
        _health.OnZeroing -= _spawner.Stop;

        _health.OnZeroing -= _updateVelocityGame.Stop;

        _health.OnZeroing -= _updateVelocityGame.Reset;

        _health.OnZeroing -= _score.Reset;

        _health.OnZeroing -= OffPLayer;
    }

    private void OffPLayer()
    {
        _player.GetComponentInChildren<Collider2D>().enabled = false;
    }

    public void StartG()
    {
        _player.transform.SetParent(null);

        if (_isFly == true)
            BindablePosition.Set(Enums.Direction.TopLeft, new Vector3(5.75f, 0f, 0f), _player.transform);

        StartGame();
    }

    private void ActivateGameObjects(bool value)
    {
        _deadZone.SetActive(value);

        _buttonMove.enabled = value;
    }

    public void InMenu()
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

        _health.Increase(_health.Max);

        _energy.Increase(_energy.Max);

        _updateVelocityGame.Start();

        _score.Start();

        _spawner.Start();

        _deadZone.SetActive(true);

        _buttonMove.enabled = true;
    }

    public void RestartGame()
    {
        _player.GetComponentInChildren<Collider2D>().enabled = true;
        ActivateGameObjects(false);

        _spawner.UnloadAll();

        BindablePosition.Set(Enums.Direction.TopLeft, new Vector3(5.75f, 0f, 0f), _player.transform);

        StartGame();
    }
}