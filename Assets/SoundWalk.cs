using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWalk : MonoBehaviour
{
    public AudioSource moveSound;

    void Update()
    {
        // if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
        Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (moveSound.isPlaying) return;
            moveSound.Play();
        }
        else
        {
            moveSound.Stop();
        }
    }
}
