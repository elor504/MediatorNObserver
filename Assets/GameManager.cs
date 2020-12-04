using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventReceiver receiver = new EventReceiver();

        EventMonitor logger = new EventLogger(receiver);
        receiver.Attach(logger);

        receiver.LogMessage("SilverPoop"," 69.742.546:25565","Scania");


        Mediator mediator = new Mediator();







        Presenter presenter = new Presenter(mediator);
        presenter.Name = "pharaoh";
        mediator.Presenter = presenter;

        Attendee Moshe = new Attendee(mediator);
        Moshe.Name = "Moshe";
        Attendee Aaron = new Attendee(mediator);
        Aaron.Name = "Aaron";
        mediator.Attendees = new List<Attendee> { Moshe, Aaron };


        StartCoroutine(Timer(Moshe, presenter));
    }


    public int LoopTimer;
    public int CurMessage;
    IEnumerator Timer(Attendee attendee, Presenter presenter)
    {

        for (int i = 0; i < LoopTimer; i++)
        {
            CurMessage++;
            QA(attendee, presenter);
            yield return new WaitForSeconds(3f);


        }

     
    }

    void QA(Attendee attendee, Presenter presenter)
    {
        switch (CurMessage)
        {
            case 1:
                attendee.AskQuestion("Let my People go!");
                break;
            case 2:
                presenter.AnswerQuestion("Hell no", attendee);
                break;
            default:
                break;
        }
    }




}


