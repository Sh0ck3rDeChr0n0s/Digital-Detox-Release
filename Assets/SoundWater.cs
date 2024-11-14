using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWater : MonoBehaviour
{
    public AudioSource waterSound;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (waterSound.isPlaying) return;
            waterSound.Play();
        }
        else
        {
            waterSound.Stop();
        }
    }
}
