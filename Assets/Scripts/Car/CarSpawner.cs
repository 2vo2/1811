using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Car _carTemplate;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Instantiate(_carTemplate, _spawnPoints[i].position, _spawnPoints[i].localRotation);
        }
    }
}
