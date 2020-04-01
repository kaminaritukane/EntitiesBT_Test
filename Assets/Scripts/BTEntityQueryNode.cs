using EntitiesBT.Components;
using EntitiesBT.Core;
using System;
using Unity.Entities;
using UnityEngine;

public class BTEntityQueryNode : BTNode<EntityQueryNode>
{
    protected override void Build(ref EntityQueryNode data, BlobBuilder builder, ITreeNode<INodeDataBuilder>[] tree)
    {
        base.Build(ref data, builder, tree);
    }
}

[Serializable]
[BehaviorNode("4BF462CB-7585-470E-92FC-441C0035D979")]
public struct EntityQueryNode : INodeData
{
    //[ReadOnly] BlobVariable<MyCubeComponent> MyCubeComp;

    [ReadOnly(typeof(ClosestEnemy))]
    public NodeState Tick(int index, INodeBlob blob, IBlackboard bb)
    {
        NodeState ret = NodeState.Running;

        if (bb.HasData<ClosestEnemy>())
        {
            var comp = bb.GetData<ClosestEnemy>();
            Debug.Log($"closestEnemy: {comp.entity}, pos: {comp.position}");
            ret = NodeState.Success;
        }
        else
        {
            ret = NodeState.Failure;
        }

        return ret;
    }

    public void Reset(int index, INodeBlob blob, IBlackboard bb)
    {

    }
}
