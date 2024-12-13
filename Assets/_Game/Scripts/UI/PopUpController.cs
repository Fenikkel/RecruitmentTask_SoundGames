using System.Collections;
using TMPro;
using UnityEngine;

public class PopUpController : Singleton<PopUpController>
{
    [SerializeField] GameObject _Container;
    [SerializeField] TextMeshProUGUI _Text;
    [Range(0f, 5f)]
    [SerializeField] float _StayTime = 2f;

    Coroutine _Coroutine;

    public void ShowPopUp(string message) 
    {
        if (_Coroutine != null) 
        {
            StopCoroutine(_Coroutine);
            _Coroutine = null;
        }

        _Coroutine = StartCoroutine(TimmerCoroutine(message));
    }

    IEnumerator TimmerCoroutine(string message)
    {        
        _Text.text = message;
        _Container.SetActive(true);
        yield return new WaitForSeconds(_StayTime);
        _Container.SetActive(false);
        _Coroutine = null;
    }
}
