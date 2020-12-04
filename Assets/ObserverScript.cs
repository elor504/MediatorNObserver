using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventReceiverBase
{
    private ArrayList _monitors = new ArrayList();

    public void Attach(EventMonitor monitor)
    {
        _monitors.Add(monitor);
    }

    public void Detach(EventMonitor monitor)
    {
        _monitors.Remove(_monitors);
    }

    public void Notify()
    {
        foreach (EventMonitor monitor in _monitors)
        {
            monitor.Update();
        }
    }
}

[SerializeField]
public class EventReceiver : EventReceiverBase
{
    private string _lastMessage;

    public string GetLastMessage()
    {
        return _lastMessage;
    }

    public void LogMessage(string UserName, string IP, string Country)
    {
        _lastMessage = "Observer Example: Logging In: " + UserName + " From: " + Country + " IP: " + IP;
        Notify();
    }
}

[SerializeField]
public abstract class EventMonitor
{
    public abstract void Update();
}


[SerializeField]
public class EventLogger : EventMonitor
{
    private EventReceiver _receiver;

    public EventLogger(EventReceiver receiver)
    {
        _receiver = receiver;
    }

    public override void Update()
    {
        string message = _receiver.GetLastMessage();
        Debug.Log(message);
    }
}