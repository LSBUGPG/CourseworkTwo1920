using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddScore : MonoBehaviour
{
    public Leaderboard leaderboard;
    Table table;

    void Update()
    {
        table = FindObjectOfType<Table>();
        Debug.Assert(table != null, "Table object not found", gameObject);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            table.AddRandomScore();
            leaderboard.Refresh();
        }
    }
}
