using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AppearingText : MonoBehaviour
{
    [SerializeField]
    private string[] _words = new string[] {"READY", "SET", "GO"};

    public string[] Words => _words;

    [SerializeField] 
    private float _waitTimeBetweenWord = 2f;

    private WaitForSeconds _waitForSeconds;

    public UnityEvent<int> OnSimpleWord;

    public UnityEvent<int> OnLastWord;

    public UnityEvent OnComplete;

    public IEnumerator UpdateText()
    {
        int index = 0;

        _waitForSeconds = new WaitForSeconds(_waitTimeBetweenWord);

        while (index <= _words.Length)
        {
            yield return _waitForSeconds;

            if (index == _words.Length - 1)
            {
//airhorn
                OnLastWord.Invoke(index);

                yield return _waitForSeconds;

                OnComplete.Invoke();

                break;
            }

            OnSimpleWord.Invoke(index);
//bass
            index++;
        }
    }
}