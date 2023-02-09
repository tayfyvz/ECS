using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

public class SpawnParallel : MonoBehaviour
{
    [SerializeField] private GameObject capsulePrefab;
    private Transform[] _arr;
    private MoveJob _moveJob;
    private JobHandle _moveHandle;
    private TransformAccessArray _transforms;

    private void Start()
    {
        _arr = new Transform[15000];
        for (int i = 0; i < 15000; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            _arr[i] = Instantiate(capsulePrefab, pos, Quaternion.identity).transform;
        }

        _transforms = new TransformAccessArray(_arr);
    }

    private void Update()
    {
        _moveJob = new MoveJob();
        _moveHandle = _moveJob.Schedule(_transforms);
    }

    private void LateUpdate()
    {
        _moveHandle.Complete();
    }

    private void OnDestroy()
    {
        _transforms.Dispose();
    }
}

struct MoveJob : IJobParallelForTransform
{
    public void Execute(int index, TransformAccess transform)
    {
        transform.position += 0.1f * (transform.rotation * new Vector3(0, 0, 1));
        if (transform.position.z > 50)
        {
            transform.position = new Vector3(transform.position.x, 0, -50);
        }
    }
}
