using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class FadingTextElement : MonoBehaviour,IInitializable
{
    [SerializeField] private float _textFadeRate;
    [SerializeField] private float _timeBeforeFade;
    [SerializeField] private bool _destroyAfterFade = true;
    private TextMeshProUGUI textComponent;

    
    [Button]
    public async Awaitable Initialize()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeText());
    }
    public void DeInitialize()
    {
        
    }

    public IEnumerator FadeText()
    {
        yield return new WaitForSecondsRealtime(_timeBeforeFade);

        while(textComponent.color.a > 0f)
        {
            textComponent.color = 
                new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, textComponent.color.a - Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        if (_destroyAfterFade)
            Destroy(gameObject);
    }

    
}
