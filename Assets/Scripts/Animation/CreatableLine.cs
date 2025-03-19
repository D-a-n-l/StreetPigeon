using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CreatableLine : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = true;

    [Space(10)]
    [SerializeField] 
    private Transform _start;

    [SerializeField]
    private Transform _end;

    [Space(10)]
    [SerializeField]
    private int _pointsCount = 50;

    [SerializeField]
    private float _length = 10;

    [Range(0, 1)]
    [SerializeField] 
    private float _rigidity = 0.5f;

    [SerializeField] 
    private float _weight = 1;

    private LineRenderer _line;

    private Vector3[] _points;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();

        if (_isStart == false)
            _line.positionCount = 0;
    }

    private void Update()
    {
        if (_isStart == false)
            return;

        if (_start == null || _end == null)
            return;

        if (_points == null || _points.Length != _pointsCount)
            _points = new Vector3[_pointsCount];

        Lerp();

        _line.positionCount = _pointsCount;
        _line.SetPositions(_points.ToArray());
    }

    public void SetState(bool value)
    {
        if (value == true)
        {
            _isStart = true;
        }
        else
        {
            _isStart = false;

            _line.positionCount = 0;
        }
    }

    private void Lerp()
    {
        var rigidity = Mathf.Clamp01(_rigidity);
        var L = (_start.position - _end.position);
        var D = L.magnitude + 0.001f;
        var DD = Mathf.Max(D, _length);
        var P0 = _start.position;
        var P1 = _start.position + _start.forward * DD * rigidity / 2;
        var P2 = _end.position - _end.forward * DD * rigidity / 2;
        var P3 = _end.position;
        var overLength = Mathf.Max(0, _length - D);

        for (int i = 0; i < _pointsCount; i++)
        {
            var t = (float)i / (_pointsCount - 1);

            //Cubic Bezier
            var P01 = Vector3.Lerp(P0, P1, t);
            var P12 = Vector3.Lerp(P1, P2, t);
            var P23 = Vector3.Lerp(P2, P3, t);
            var P012 = Vector3.Lerp(P01, P12, t);
            var P123 = Vector3.Lerp(P12, P23, t);
            var P1234 = Vector3.Lerp(P012, P123, t);

            //add gravity
            var t1 = (t - 0.5f) * 2;//linear -1 : 0 : 1
            var t2 = t1 * t1;//parabola 1 : 0 : 1
            var t3 = 1 - t2;//parabola 0 : 1 : 0
            var gravity = Vector3.up * (t2 * t2 - 1) * _weight * t3 * (1 - rigidity) * overLength;

            P1234 += gravity;

            _points[i] = P1234;
        }
    }
}