using EntitiesBT.Components;
using EntitiesBT.Core;
using EntitiesBT.Variable;
using MyVariable;
using Unity.Entities;
using UnityEngine;

public class BTVariableNode : BTNode<VariableNode>
{
    [SerializeReference, SerializeReferenceButton]
    public Int32Property IntVariable;

    protected override void Build(ref VariableNode data, BlobBuilder builder, ITreeNode<INodeDataBuilder>[] tree)
    {
        IntVariable.Allocate(ref builder, ref data.IntBlobVariable, this, tree);
    }
}

[BehaviorNode("45603249-3644-4214-8D54-9DFECBF2A2F9")]
public struct VariableNode : INodeData
{
    public BlobVariable<int> IntBlobVariable;

    public NodeState Tick(int index, INodeBlob blob, IBlackboard blackboard)
    {
        var intVariable = IntBlobVariable.GetData(index, blob, blackboard);// by value
        //ref var intVariable = IntBlobVariable.GetDataRef(index, blob, blackboard); // by reference
        return NodeState.Success;
    }

    public void Reset(int index, INodeBlob blob, IBlackboard blackboard) { }
}
