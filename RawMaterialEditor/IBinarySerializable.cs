namespace RawMaterialEditor;

internal interface IBinarySerializable<T>
{
	static abstract T Deserialize(BinaryReader reader);

	void Serialize(BinaryWriter writer);
}
