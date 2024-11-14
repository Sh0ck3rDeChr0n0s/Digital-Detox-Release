using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CheckAllObjectsInScene : MonoBehaviour
{
    [SerializeField] private Image _image;
    private EnemyHp[] enemys;
    private List<EnemyHp> enemysList = new List<EnemyHp>();
    private Cleaning[] clean;
    private List<Cleaning> cleanList = new List<Cleaning>();
    private float _max;
    public int num;
    public bool f = false;
    private void Start()
    {
        // ����� ��� ������� � ����������� Rigidbody, ������� ���������� �������
        enemys = FindObjectsOfType<EnemyHp>(true);
        clean = FindObjectsOfType<Cleaning>(true);
        _max = enemys.Length + clean.Length;
        foreach (EnemyHp enemy in enemys)
        {
            enemysList.Add(enemy);
        }
        foreach (Cleaning enemy in clean)
        {
            cleanList.Add(enemy);
        }
        _image.fillAmount = 0f;
    }
    private void Update()
    {
        _image.fillAmount = (_max-(enemysList.Count + cleanList.Count))/_max;
        // Debug.Log(enemysList.Count);
        enemysList.RemoveAll(enemys => enemys.Hp < 0);
        cleanList.RemoveAll(enemys => enemys.isCleaned == true);

        if ((cleanList.Count <= 0) && (enemysList.Count <= 0))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(num);
        }
        else if (f && cleanList.Count == clean.Length - 1)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(num);
        }
    }
}
