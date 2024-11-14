using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _brizgPoint;
    [SerializeField] private GameObject _brizg;
    [SerializeField] private ParticleSystem _brizgi;
    [SerializeField] private GameObject _shlang;
    private Vector3 _start, _end;
    private void Start()
    {
        _end = new Vector3(0f, 0f, 0f);
        _start = new Vector3(0.5f, 0.5f, 13f);
    }

    private void Update()
    {
        _brizg.transform.position = Vector3.Lerp(_brizg.transform.position ,_brizgPoint.position, 10f * Time.deltaTime);
        _brizg.transform.rotation = Quaternion.Lerp(_brizg.transform.rotation, _brizgPoint.rotation, Time.deltaTime *10f);
        _shlang.transform.position = Vector3.Lerp(_brizg.transform.position, _brizgPoint.position, 10f * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            _brizg.transform.localScale = _start;
            _brizgi.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _brizg.transform.localScale = _end;
            _brizgi.Stop();
        }
    }
}
