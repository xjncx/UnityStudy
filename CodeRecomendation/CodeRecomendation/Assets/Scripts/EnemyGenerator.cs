using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<Transform> _pointsToSpawn;

    private bool _isSpawning = true;
    private WaitForSeconds _waitForTwoSeconds = new WaitForSeconds(2);

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private Enemy GetNewInstance()
    {
        Vector3 prefabPosition = _pointsToSpawn[Random.Range(0, _pointsToSpawn.Count)].position;
        return Instantiate(_prefab, prefabPosition, Quaternion.identity);
    }

    private IEnumerator Spawn()
    {
        while (_isSpawning)
        {
            GetNewInstance();
            yield return _waitForTwoSeconds;
        }
    }
}
