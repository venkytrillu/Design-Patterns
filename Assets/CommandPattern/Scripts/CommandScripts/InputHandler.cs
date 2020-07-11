using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator anim;
    Command keyJump, keyKick, keyPunch, KeyUpArrow;
    List<Command> oldCommands = new List<Command>();

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;

    // Start is called before the first frame update
    void Start()
    {
        keyJump = new PerformJump();
        keyKick = new PerformKick();
        keyPunch = new PerformPunch();
        KeyUpArrow = new MoveForward();
        anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReplaying)
            HandleInput();
        StartReplay();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyJump.Execute(anim, true);
            oldCommands.Add(keyJump);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            keyKick.Execute(anim, true);
            oldCommands.Add(keyKick);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            keyPunch.Execute(anim, true);
            oldCommands.Add(keyPunch);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            KeyUpArrow.Execute(anim, true);
            oldCommands.Add(KeyUpArrow);
        }

        if (Input.GetKeyDown(KeyCode.R))
            shouldStartReplay = true;

        if (Input.GetKeyDown(KeyCode.U))
            UndoLastCommand();

    }

    void UndoLastCommand()
    {
        if (oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    void StartReplay()
    {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if(replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        isReplaying = true;

        for(int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim, true);
            yield return new WaitForSeconds(1f);
        }

        isReplaying = false;
    }
}
