using UnityEngine;
using TMPro;
using NaughtyAttributes;
public class ConsoleMessagesController : MonoBehaviour, IInitializable
{
    private GameObject messagePrefab;
    public async Awaitable Initialize()
    {
        messagePrefab = Resources.Load("UI/ConsoleMessage") as GameObject;
    }

    [Button]
    public void TestMessage()
    {
        PushMessage("Hello! Welcome to Test Message.");
    }
    
    public void PushMessage(string content)
    {
        GameObject g = Instantiate(messagePrefab, transform);
        g.GetComponent<TextMeshProUGUI>().text = content;
        g.GetComponent<FadingTextElement>().Initialize();
    }
    

    void Start()
    {
        Initialize();
    }

    public void DeInitialize()
    {

    }

}
