using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class Leaderboard : MonoBehaviour
{
    public Rank rowPrefab;
    Table table;

    List<Rank> leaderboard;

    void Start()
    {
        table = FindObjectOfType<Table>();
        if (table != null)
        {
            table.Create();            
            VerticalLayoutGroup group = GetComponent<VerticalLayoutGroup>();
            leaderboard = new List<Rank>();
            for (int i = 0; i < table.size; ++i)
            {
                leaderboard.Add(Instantiate(rowPrefab, transform));
            }
            Refresh();
        }
    }

    public void Refresh()
    {
        if (table != null && leaderboard != null)
        {
            table.ShowRanks(leaderboard);
        }
    }
}
