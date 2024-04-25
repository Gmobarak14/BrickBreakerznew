using UnityEngine;
using TMPro;
using System.Collections;

public class Flicker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textBox;
    
    [Range(0.7f,2.0f)]
    [SerializeField] float _flickerInterval = 0.73f;

    bool _onCoroutine = false;
    void Start()
    {
        _textBox = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        if (! _onCoroutine){
        StartCoroutine(FlickerText());
        }
    }
    IEnumerator FlickerText(){
        _onCoroutine = true;
        _textBox.enabled = !_textBox.enabled;
        yield return new WaitForSeconds(_flickerInterval);
        _onCoroutine = false;
    }
}
