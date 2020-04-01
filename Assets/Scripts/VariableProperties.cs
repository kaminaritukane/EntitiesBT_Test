namespace MyVariable
{

public interface Int32Property { void Allocate(ref Unity.Entities.BlobBuilder builder, ref EntitiesBT.Variable.BlobVariable<System.Int32> blobVariable, EntitiesBT.Core.INodeDataBuilder self, EntitiesBT.Core.ITreeNode<EntitiesBT.Core.INodeDataBuilder>[] tree); }
public class Int32ComponentVariableProperty : EntitiesBT.Variable.ComponentVariableProperty<System.Int32>, Int32Property { }
public class Int32CustomVariableProperty : EntitiesBT.Variable.CustomVariableProperty<System.Int32>, Int32Property { }
public class Int32NodeVariableProperty : EntitiesBT.Variable.NodeVariableProperty<System.Int32>, Int32Property { }
public class Int32ScriptableObjectVariableProperty : EntitiesBT.Variable.ScriptableObjectVariableProperty<System.Int32>, Int32Property { }

public interface float3Property { void Allocate(ref Unity.Entities.BlobBuilder builder, ref EntitiesBT.Variable.BlobVariable<Unity.Mathematics.float3> blobVariable, EntitiesBT.Core.INodeDataBuilder self, EntitiesBT.Core.ITreeNode<EntitiesBT.Core.INodeDataBuilder>[] tree); }
public class float3ComponentVariableProperty : EntitiesBT.Variable.ComponentVariableProperty<Unity.Mathematics.float3>, float3Property { }
public class float3CustomVariableProperty : EntitiesBT.Variable.CustomVariableProperty<Unity.Mathematics.float3>, float3Property { }
public class float3NodeVariableProperty : EntitiesBT.Variable.NodeVariableProperty<Unity.Mathematics.float3>, float3Property { }
public class float3ScriptableObjectVariableProperty : EntitiesBT.Variable.ScriptableObjectVariableProperty<Unity.Mathematics.float3>, float3Property { }


}

