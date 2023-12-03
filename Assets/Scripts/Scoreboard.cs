using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : NetworkBehaviour
{
    [SyncVar(hook = nameof(HandleLeftScoreUpdated))]
    int leftScore;
    [SyncVar(hook = nameof(HandleRightScoreUpdated))]
    int rightScore;
    public static event Action<int> ClientOnLeftScoreUpdated;
    public static event Action<int> ClientOnRightScoreUpdated;

    public override void OnStartServer()
    {
        Ball.onGoal += ServerHandleGoal;
    }

    void ServerHandleGoal(string side)
    {
        if (side == "Right")
        {
            leftScore++;           
        }

        else
        {
            rightScore++;
        }

        print($"Left score:{leftScore}");
        print($"Right score:{rightScore}");
    }
    
    public override void OnStopServer()
    {
        Ball.onGoal -= ServerHandleGoal;
    }

    void HandleLeftScoreUpdated(int oldScore, int newScore)
    {

        ClientOnLeftScoreUpdated?.Invoke(newScore);

    }

    void HandleRightScoreUpdated(int oldScore, int newScore)
    {

        ClientOnRightScoreUpdated?.Invoke(newScore);

    }
}
