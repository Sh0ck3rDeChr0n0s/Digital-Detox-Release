using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    private Bug bug;
    public CleaningManager cln;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bug"))
        {
            bug = other.GetComponent<Bug>();
            print(bug.Hp);
            print(cln.Num_bugs);
            if (bug.Hp == 1)
            {
                cln.Num_bugs--;
                bug.TakeDamage(1);
            }
            else
            {
                bug.TakeDamage(1);
            }
        }
    }
}
