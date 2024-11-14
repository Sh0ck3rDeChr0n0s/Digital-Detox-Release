using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    private AudioSource[] _aSource;
    [SerializeField] private Slider _slider;
    private void Start()
    {
        _aSource = FindObjectsOfType<AudioSource>(true);
    }
    private void Update()
    {
        foreach (AudioSource source in _aSource)
        {
            source.volume = _slider.value;
        }
        // Debug.Log(_aSource.Length);
    }
}
