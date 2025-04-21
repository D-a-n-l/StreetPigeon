using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private PresetAnimation _animation;

    [SerializeField]
    private Image _image;

    private int _currentFrame = 0;

    private float _timer = 0;

    public void Init(PresetAnimation animation)
    {
        _animation = animation;
    }

    private void Update()
    {
        if (_animation == null || _animation.Frames.Length == 0)
            return;

        if (_timer > 1 / _animation.FrameRate)
        {
            _currentFrame++;

            if (_currentFrame >= _animation.Frames.Length)
            {
                _currentFrame = 0;
            }

            _image.sprite = _animation.Frames[_currentFrame];

            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}