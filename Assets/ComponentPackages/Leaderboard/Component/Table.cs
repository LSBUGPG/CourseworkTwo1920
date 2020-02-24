using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int size = 10;
    public int minimumInitialScore;
    public int maximumInitialScore;
    public int scoreIncrement;
    public string [] initialNames = { "Random Name" };

    struct RankData
    {
        public string name;
        public int score;

        public RankData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    List<RankData> table = new List<RankData>();

    string RandomName()
    {
        return initialNames[Random.Range(0, initialNames.Length)];
    }

    int RandomScore()
    {
        int min = minimumInitialScore / scoreIncrement;
        int max = maximumInitialScore / scoreIncrement;
        return Random.Range(min, max) * scoreIncrement;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Create()
    {
        for (int i = 0; i < size; ++i)
        {
            AddRandomScore();
        }
    }

    public void AddRandomScore()
    {
        AddScore(RandomName(), RandomScore());
    }

    public void AddScore(string name, int score)
    {
        table.Add(new RankData(name, score));
        table.Sort((x, y) => y.score.CompareTo(x.score));
        if (table.Count > size)
        {
            table.RemoveRange(size, table.Count - size);
        }
    }

    public void ShowRanks(List<Rank> ranks)
    {
        for (int i = 0; i < ranks.Count; ++i)
        {
            if (i < table.Count)
            {
                ranks[i].SetRank(i + 1);
                ranks[i].SetName(table[i].name);
                ranks[i].SetScore(table[i].score);
            }
        }
    }
}
