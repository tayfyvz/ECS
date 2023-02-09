using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class ECSManager : MonoBehaviour
{
    [SerializeField] private GameObject capsulePrefab;
    [SerializeField] private int prefabNum;
    private EntityManager _manager;

    private void Start()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        Entity prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(capsulePrefab, settings);
        for (int i = 0; i < prefabNum; i++)
        {
            Entity instance = _manager.Instantiate(prefab);
            Vector3 position = transform.TransformPoint(new float3(UnityEngine.Random.Range(-50, 50),
                UnityEngine.Random.Range(-50, 50),
                UnityEngine.Random.Range(-50, 50)));
            _manager.SetComponentData(instance, new Translation {Value = position});
            _manager.SetComponentData(instance, new Rotation {Value = new quaternion(0,0,0,0)});
        }
    }
}

