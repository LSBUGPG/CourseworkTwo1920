using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationLeader : MonoBehaviour
{
    public List<FormationFlyer> row;
    public int columns = 11;
    public int rowSpacing = 25;
    public int columnSpacing = 25;

    List<FormationFlyer> squad = new List<FormationFlyer>();
    bool limit = false;
    bool win = false;

    void Start()
    {
        for (int r = 0; r < row.Count; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                Vector3 position = transform.position;
                position.x += c * columnSpacing;
                position.z += r * rowSpacing;
                FormationFlyer f = Instantiate(row[r]);
                f.leader = this;
                f.transform.position = position;
                squad.Add(f);
            }
        }

        StartCoroutine(Advance());
    }

    IEnumerator MoveSquad(Vector3 direction)
    {
        // remove any dead fighters
        squad.RemoveAll((flyer) => flyer == null);

        foreach (FormationFlyer f in squad)
        {
            if (f != null)
            {
                f.Move(direction);
            }
            yield return new WaitForSeconds(1.0f / 60.0f);
            if (win)
            {
                break;
            }
        }
    }

    IEnumerator Advance()
    {
        Vector3 direction = Vector3.left;
        while (squad.Count > 0 && !win)
        {
            if (limit)
            {
                yield return StartCoroutine(
                    MoveSquad(Vector3.forward * -5.0f));

                direction.x *= -1.0f;
                limit = false;
            }
            yield return StartCoroutine(MoveSquad(direction * 5.0f));
        }
    }

    void ReachedZone(string zone)
    {
        if (zone == "LeftLimit" || zone == "RightLimit")
        {
            limit = true;
        }
        else if (zone == "Target")
        {
            win = true;
        }
    }
}
