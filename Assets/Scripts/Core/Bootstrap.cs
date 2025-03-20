using System.Collections;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [field: SerializeField]
    public StepByStepAnimation ButtonStart { get; private set; }

    [Space(10)]
    [SerializeField]
    private Canvas _buttonsMove;

    [Space(10)]
    [SerializeField]
    private GameObject _deadZoneTop;

    [SerializeField]
    private GameObject _deadZoneBottom;

    private Spawner _spawner;

    private RefrashableTimeScaleFromScore _refrashableTimeScale;

    private SettableSkin _settableSkin;

    private Health _health;

    private Energy _energy;

    private Score _score;

    private GameObject _player => _settableSkin.Current;

    private bool _isFly = false;

    [Inject]
    public void Construct(Health health, Energy energy, Score score, RefrashableTimeScaleFromScore refrashableTimeScale, SettableSkin settableSkin, SpawnerConfig spawnerConfig)
    {
        _settableSkin = settableSkin;

        _score = score;

        _refrashableTimeScale = refrashableTimeScale;

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
        //ActivateGameObjects(false);

        _health.OnZeroing += _spawner.Stop;

        _health.OnZeroing += _refrashableTimeScale.Stop;

        _health.OnZeroing += _refrashableTimeScale.Reset;

        _health.OnZeroing += _score.Reset;

        _health.OnZeroing += OffPLayer;
    }

    private void Start()
    {
        BindablePosition.Set(BindablePositionConst.DeadZoneTop, _deadZoneTop.transform);

        BindablePosition.Set(BindablePositionConst.DeadZoneBottom, _deadZoneBottom.transform);
    }

    private void OnDisable()
    {
        _health.OnZeroing -= _spawner.Stop;

        _health.OnZeroing -= _refrashableTimeScale.Stop;

        _health.OnZeroing -= _refrashableTimeScale.Reset;

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
            BindablePosition.Set(BindablePositionConst.Pigeon, _player.transform);

        StartGame();
    }

    private void ActivateGameObjects(bool value)
    {
        _deadZoneTop.SetActive(value);

        _buttonsMove.enabled = value;
    }

    public void InMenu()
    {
        _spawner.Stop();

        _refrashableTimeScale.Reset();

        _refrashableTimeScale.Stop();

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

        _refrashableTimeScale.Start();

        _score.Start();

        _spawner.Start();

        _deadZoneTop.SetActive(true);

        _buttonsMove.enabled = true;
    }

    public void RestartGame()
    {
        _player.GetComponentInChildren<Collider2D>().enabled = true;
        ActivateGameObjects(false);

        _spawner.UnloadAll();

        BindablePosition.Set(BindablePositionConst.Pigeon, _player.transform);

        StartGame();
    }
}