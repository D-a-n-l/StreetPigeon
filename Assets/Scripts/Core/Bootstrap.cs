using System.Collections;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private SaverStartPosition _player;

    [SerializeField]
    private GameObject _topDeadZone;

    [SerializeField]
    private GameObject _buttonMove;

    [Space(10)]
    [SerializeField]
    private float _timeSpawnPlayer = 4f;

    [SerializeField]
    private float _timeActiveButtonAndDeadZone = 3f;

    private WaitForSeconds _waitTimeSpawnPlayer;

    private WaitForSeconds _waitTimeButtonAndDeadZone;

    private LoopSpawnObject _loopSpawnObject;

    private Score _score;

    private UpdateVelocityGame _updateVelocityGame;

    private AppearingText _appearingText;

    private Health _health;

    private Energy _energy;

    [Inject]
    public void Construct(Health health, Energy energy, LoopSpawnObject loopSpawnObject, Score score, UpdateVelocityGame updateVelocityGame, AppearingText appearingText)
    {
        _loopSpawnObject = loopSpawnObject;

        _score = score;

        _updateVelocityGame = updateVelocityGame;

        _appearingText = appearingText;

        _health = health;

        _energy = energy;
    }

    private void Awake()
    {
        ActivateGameObjects(false);
    }

    private void Start()
    {
        _waitTimeSpawnPlayer = new WaitForSeconds(_timeSpawnPlayer);

        _waitTimeButtonAndDeadZone = new WaitForSeconds(_timeActiveButtonAndDeadZone);

        _loopSpawnObject.Init();

        StartCoroutine(StartGame());
    }

    private void ActivateGameObjects(bool value)
    {
        _player.gameObject.SetActive(value);

        _topDeadZone.SetActive(value);

        _buttonMove.SetActive(value);
    }

    private IEnumerator StartGame()
    {
        _updateVelocityGame.Reset();

        StartCoroutine(_updateVelocityGame.Increase());

        StartCoroutine(_appearingText.UpdateText());

        StartCoroutine(_loopSpawnObject.Load());

        yield return _waitTimeSpawnPlayer;

        _player.gameObject.SetActive(true);

        yield return _waitTimeButtonAndDeadZone;

        _topDeadZone.SetActive(true);

        _buttonMove.SetActive(true);
    }

    public void RestartGame()
    {
        _health.Increase(_health.Max);
        _energy.Increase(_energy.Max);

        ActivateGameObjects(false);

        LocalAssetLoader.UnloadAlll();

        _score.Reset();

        _player.transform.SetPositionAndRotation(_player.SavedPosition, Quaternion.identity);

        StartCoroutine(StartGame());
    }
}