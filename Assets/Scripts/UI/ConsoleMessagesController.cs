/*****************************************************************************
// File Name : ConsoleMessagesController.cs
// Author : Pierce Nunnelley
// Creation Date : February 26, 2026
//
// Brief Description : This is a script for a basic console-esque text interface.
*****************************************************************************/
using UnityEngine;
using TMPro;
using NaughtyAttributes;
public class ConsoleMessagesController : MonoBehaviour, IInitializable
{
    private GameObject messagePrefab;
    public async Awaitable Initialize()
    {
        messagePrefab = Resources.Load("UI/ConsoleMessage") as GameObject;
        await Awaitable.EndOfFrameAsync();
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
    

    public void DeInitialize()
    {

    }

}
