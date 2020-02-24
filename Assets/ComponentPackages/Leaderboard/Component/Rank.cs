using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public Text rank;
    new public Text name;
    public Text score;

    public void SetRank(int rank)
    {
        this.rank.text = rank.ToString();
    }

    public void SetName(string name)
    {
        this.name.text = name;
    }
    public void SetScore(int score)
    {
        this.score.text = score.ToString("0,0");
    }
}
