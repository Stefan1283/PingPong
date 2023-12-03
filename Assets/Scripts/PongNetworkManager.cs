using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongNetworkManager : NetworkManager    
{
    [SerializeField] Transform LeftPadelSpawn, RightPadelSpawn;
    [SerializeField] GameObject BallPrefab, ScoreboardPrefab;
    GameObject ball, Scoreboard;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform start = numPlayers == 0 
            ? LeftPadelSpawn 
            : RightPadelSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        if (numPlayers == 2)
        {
           ball = Instantiate(BallPrefab);
           NetworkServer.Spawn(ball); 
           Scoreboard = Instantiate(ScoreboardPrefab);
           NetworkServer.Spawn(Scoreboard);
        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        
        if (ball)
        {
            NetworkServer.Destroy(ball);
        }
        if (Scoreboard)
        {
            NetworkServer.Destroy(Scoreboard);
        }
    }
}
