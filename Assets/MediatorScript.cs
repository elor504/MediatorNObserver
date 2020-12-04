using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MediatorScript
{
    protected Mediator _mediator;




    protected MediatorScript(Mediator mediator)
    {
       this._mediator = mediator;
    }

    public string Name { get; set; }
    public void ReceiveAnswer(string answer)
    {
        Debug.Log("Recieved Answer: " + answer);
    }

}
[Serializable]
public class Presenter : MediatorScript
{
    public Presenter(Mediator mediator) : base(mediator) { }


    public void ReceiveQuestion (string Question,Attendee attendee)
    {
        Debug.Log("Presenter received question from " + attendee.Name +  " : " + Question);
    }
    public void AnswerQuestion(string answer, Attendee attendee)
    {
        Debug.Log("Presenter answered question for from " + attendee.Name + " : " + answer);

        _mediator.SendAnswer(answer, attendee);
    }
}
[SerializeField]
public class Attendee : MediatorScript
{

    public Attendee(Mediator mediator) : base(mediator) { }


    public void AskQuestion(string question)
    {
        Debug.Log(Name + " asked question " + question);
        _mediator.SendQuestion(question, this);
    }
    }
[Serializable]
public class Mediator
{
	public Presenter Presenter { get; set; }

	public List<Attendee> Attendees { get; set; }

 
    public void SendAnswer(string answer, Attendee attendee)
    {
        attendee.ReceiveAnswer(answer);
    }
 
    public void SendQuestion(string question, Attendee attendee)
    {
        Presenter.ReceiveQuestion(question, attendee);
    }

}