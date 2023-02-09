using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

// public partial class MoveSystem : SystemBase
// {
//     protected override void OnUpdate()
//     {
//         Entities.WithName("MoveSystem").ForEach((ref Translation position, ref Rotation rotation) =>
//         {
//             position.Value.y += .1f;
//             if (position.Value.y > 50)
//             {
//                 position.Value.y = 0;
//             }
//         }).Schedule();
//     }
// }

public partial class MoveSystem2 : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithName("UpSystem").ForEach((
            ref Translation position, 
            ref Rotation rotation,
            ref CubeData cubeData) =>
        {
            position.Value += .1f * math.up();
            
        }).Schedule();
        
    }
}