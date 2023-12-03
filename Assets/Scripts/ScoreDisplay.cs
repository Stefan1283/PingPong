using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] Text leftText, rightText;

    // Start is called before the first frame update
    void Start()
    {
        Scoreboard.ClientOnLeftScoreUpdated += HandleLeftScoreUpdate;
        Scoreboard.ClientOnRightScoreUpdated += HandleRightScoreUpdate;
    }

    private void OnDestroy()
    {
        Scoreboard.ClientOnLeftScoreUpdated -= HandleLeftScoreUpdate;
        Scoreboard.ClientOnRightScoreUpdated -= HandleRightScoreUpdate;
    }

    void HandleLeftScoreUpdate(int score)
    {
        leftText.text = score.ToString();
    }

    void HandleRightScoreUpdate(int score)
    {
        rightText.text = score.ToString();
    }
}
