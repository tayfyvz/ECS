using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSInterface : MonoBehaviour
{
    private World _world;
    private void Start()
    {
        _world = World.DefaultGameObjectInjectionWorld;
        Debug.Log("All entities: " + _world.GetExistingSystem<MoveSystem2>().EntityManager.GetAllEntities().Length);

        EntityManager manager = _world.GetExistingSystem<MoveSystem2>().EntityManager;
        EntityQuery entityQuery = manager.CreateEntityQuery(ComponentType.ReadOnly<CubeData>());
        Debug.Log("Cube data: "+entityQuery.CalculateEntityCount());
    }
}
