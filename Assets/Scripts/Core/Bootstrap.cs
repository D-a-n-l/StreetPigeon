using System.Collections;
using System.Threading.Tasks;
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

    private Health _health;

    private Energy _energy;

    private Spawner _spawner;

    private RefrashableTimeScaleFromScore _refrashableTimeScale;

    private Score _score;

    private SettableSkin _settableSkin;

    private GameObject Player => _settableSkin.Current;

    private Collider2D _playerCollider;

    private WaitForSeconds _waitSeconds;

    private bool _isFly = false;

    [Inject]
    public void Construct(Health health, Energy energy, Score score, SpawnerConfig spawnerConfig, 
        RefrashableTimeScaleFromScore refrashableTimeScale, SettableSkin settableSkin)
    {
        _health = health;

        _energy = energy;

        _score = score;

        _spawner = new Spawner(spawnerConfig, transform, _score);

        _refrashableTimeScale = refrashableTimeScale;

        _settableSkin = settableSkin;

        _waitSeconds = new WaitForSeconds(1f);
    }

    private void Awake()
    {
        _health.OnZeroing += _spawner.Stop;

        _health.OnZeroing += _refrashableTimeScale.Stop;

        _health.OnZeroing += _refrashableTimeScale.Reset;

        _health.OnZeroing += _score.Reset;

        _health.OnZeroing += () => PlayerCollider(false);

        _health.OnZeroing += () => StartCoroutine(ActivateDeadZonesAndButtonsMove(false));
    }

    private void OnDisable()
    {
        _health.OnZeroing -= _spawner.Stop;

        _health.OnZeroing -= _refrashableTimeScale.Stop;

        _health.OnZeroing -= _refrashableTimeScale.Reset;

        _health.OnZeroing -= _score.Reset;

        _health.OnZeroing -= () => PlayerCollider(false);

        _health.OnZeroing -= () => StartCoroutine(ActivateDeadZonesAndButtonsMove(false));
    }

    private void Start()
    {
        print(BindablePosition.Get());


        BindablePosition.Set(BindablePositionConst.DeadZoneTop, _deadZoneTop.transform);

        BindablePosition.Set(BindablePositionConst.DeadZoneBottom, _deadZoneBottom.transform);

        StartCoroutine(ActivateDeadZonesAndButtonsMove(false));
    }

    public void SetIsFly(bool value) => _isFly = value;

    public void SetIsGame(bool value) => GameState.Set(value);

    public void StartGame()
    {
        Player.transform.SetParent(null);

        if (_isFly == true)
            BindablePosition.Set(BindablePositionConst.Pigeon, Player.transform);

        Player.GetComponent<MovingPlayer>().enabled = true;

        _health.Increase(_health.Max);

        _energy.Increase(_energy.Max);

        _spawner.Start();

        _refrashableTimeScale.Start();

        _score.Start();

        if (Player.transform.localScale != Vector3.one)
            RescaleSprite.Rescale(Player.transform, Vector3.one, 2f);

        StartCoroutine(ActivateDeadZonesAndButtonsMove(true));
    }

    public async Task RestartGame()
    {
        await _spawner.UnloadAll();

        PlayerCollider(true);

        BindablePosition.Set(BindablePositionConst.Pigeon, Player.transform);

        StartGame();
    }

    public async Task InMenu()
    {
        _spawner.Stop();

        PlayerCollider(false);

        await _spawner.UnloadAll();

        _refrashableTimeScale.Stop();

        _refrashableTimeScale.Reset();

        _score.Reset();

        _settableSkin.SetLast();

        StartCoroutine(ActivateDeadZonesAndButtonsMove(false));
    }

    private void PlayerCollider(bool enabled)
    {
        if (_playerCollider == null)
            _playerCollider = Player.GetComponentInChildren<Collider2D>();

        _playerCollider.enabled = enabled;
    }

    private IEnumerator ActivateDeadZonesAndButtonsMove(bool value)
    {
        if (value == true)
            yield return _waitSeconds;

        _buttonsMove.enabled = value;

        _deadZoneTop.SetActive(value);

        _deadZoneBottom.SetActive(value);
    }
}