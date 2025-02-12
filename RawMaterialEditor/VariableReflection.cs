namespace RawMaterialEditor;

internal struct VariableReflection : IBinarySerializable<VariableReflection>
{
	public Klass Klass { get; set; }

	public uint Elements { get; set; }

	public uint Name { get; set; }

	public uint Offset { get; set; }

	public uint ElementStride { get; set; }

	public static VariableReflection Deserialize(BinaryReader reader)
	{
		var reflect = new VariableReflection();
		reflect.Klass = (Klass)reader.ReadUInt32();
		reflect.Elements = reader.ReadUInt32();
		reflect.Name = reader.ReadUInt32();
		reflect.Offset = reader.ReadUInt32();
		reflect.ElementStride = reader.ReadUInt32();
		return reflect;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Klass);
		writer.Write(Elements);
		writer.Write(Name);
		writer.Write(Offset);
		writer.Write(ElementStride);
	}
}
