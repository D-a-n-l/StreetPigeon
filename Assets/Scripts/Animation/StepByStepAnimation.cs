using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static DG.Tweening.DOTweenCYInstruction;

public class StepByStepAnimation : MonoBehaviour
{
    [SerializeField]
    private Enums.BaseStepAnimation _baseStep;

    [SerializeField]
    private Enums.EventsStepAnimation _events;

    [SerializeField]
    [HideIf(nameof(_events), Enums.EventsStepAnimation.Invoker)]
    private string _keySubscriber;

    //[SerializeField]
    //[ShowIf(nameof(_events), Enums.EventsStepAnimation.Invoker)]
    //private string _keyInvoker;

    [Space(10)]
    [SerializeField]
    private UpdateType _updateType = UpdateType.Normal;

    [SerializeField]
    private bool _isIndependentUpdate = false;

    [Space(10)]
    [SerializeField]
    private StepPreset[] _startStep;

    [SerializeField]
    private StepPreset[] _endStep;

    [Space(10)]
    [SerializeField]
    private bool _isCallPrestartedEvent;

    [SerializeField]
    [ShowIf(nameof(_isCallPrestartedEvent))]
    private string _keyPrestarted;

    [SerializeField]
    private UnityEvent OnPrestarted;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        switch (_baseStep)
        {
            case Enums.BaseStepAnimation.Start:
                StartStepWithoutEvent(true);
                break;
            case Enums.BaseStepAnimation.End:
                StartStepWithoutEvent(false);
                break;
            case Enums.BaseStepAnimation.None:
                break;
        }

        switch (_events)
        {
            case Enums.EventsStepAnimation.Subscriber:
                StepAnimationEvents.StartStep += StartStepWithEvent;
                break;
            case Enums.EventsStepAnimation.SubscriberInvoker:
                StepAnimationEvents.StartStep += StartStepWithEvent;
                break;
            case Enums.EventsStepAnimation.None:
                break;
        }
    }

    private void OnDisable()
    {
        if (_events == Enums.EventsStepAnimation.Subscriber ||
            _events == Enums.EventsStepAnimation.SubscriberInvoker)
            StepAnimationEvents.StartStep -= StartStepWithEvent;
    }

    public void StartStepWithEvent(bool startStep)
    {
        //ждем выполнение корутины до конца
        StartCoroutine(StartStepWithEventCoroutine(startStep));
    }

    public IEnumerator StartStepWithEventCoroutine(bool startStep)
    {
        yield return _currentCoroutine;
             
        _currentCoroutine = StartCoroutine(StartStepCoroutine(startStep, true));
    }

    public void StartStepWithoutEvent(bool startStep)
    {
        //ждем выполнение корутины до конца
        StartCoroutine(StartStepWithoutEventCoroutine(startStep));
    }

    public IEnumerator StartStepWithoutEventCoroutine(bool startStep)
    {
        yield return _currentCoroutine;

        _currentCoroutine = StartCoroutine(StartStepCoroutine(startStep, false));
    }

    private IEnumerator StartStepCoroutine(bool startStep, bool isEvent)
    {
        if (isEvent == true)
        {
            if (_events == Enums.EventsStepAnimation.Subscriber || _events == Enums.EventsStepAnimation.SubscriberInvoker)
            {
                if (_keySubscriber != StepAnimationEvents.CurrentKey)
                {
                    //print(_keySubscriber);
                    //print(StepAnimationEvents.CurrentKey);
                    yield break;
                }
            }
        }

        OnPrestarted?.Invoke();

        if ((_events == Enums.EventsStepAnimation.Invoker || _events == Enums.EventsStepAnimation.SubscriberInvoker) && _isCallPrestartedEvent == true)
        {
            StepAnimationEvents.SetKey(_keyPrestarted);
            StepAnimationEvents.Invoke(!startStep);
        }

        StepPreset[] preset;

        if (startStep == true)
            preset = _startStep;
        else
            preset = _endStep;

        for (int i = 0; i < preset.Length; i++)
        {
            preset[i].OnStarted?.Invoke();

            if ((_events == Enums.EventsStepAnimation.Invoker || _events == Enums.EventsStepAnimation.SubscriberInvoker) && preset[i].IsCallStartedEvent == true)
            {
                StepAnimationEvents.SetKey(preset[i].KeyStarted);
                StepAnimationEvents.Invoke(preset[i].StepStarted);
                //StepAnimationEvents.Invoke(!startStep);
            }

            yield return new WaitForCompletion(preset[i].RectTransform.DOAnchorPos(preset[i].Position, preset[i].Duration).SetEase(preset[i].Ease).SetUpdate(_updateType, _isIndependentUpdate));

            preset[i].OnCompleted?.Invoke();

            if ((_events == Enums.EventsStepAnimation.Invoker || _events == Enums.EventsStepAnimation.SubscriberInvoker) && preset[i].IsCallCompletedEvent == true)
            {
                StepAnimationEvents.SetKey(preset[i].KeyCompleted);
                StepAnimationEvents.Invoke(preset[i].StepCompleted);
                //StepAnimationEvents.Invoke(!startStep);
            }
        }
    }
}

[System.Serializable]
public struct StepPreset
{
    public RectTransform RectTransform;

    public Ease Ease;

    public Vector3 Position;

    public Quaternion Rotation;

    public float Duration;

    public bool IsCallStartedEvent;

    public string KeyStarted;

    public bool StepStarted;

    public UnityEvent OnStarted;

    public bool IsCallCompletedEvent;

    public string KeyCompleted;

    public bool StepCompleted;

    public UnityEvent OnCompleted;
}