using System.ComponentModel;

namespace RawMaterialEditor;

[TypeConverter(typeof(ExpandableObjectConverter))]
internal struct TextureChannel : IBinarySerializable<TextureChannel>
{
	public uint Channel { get; private set; }

	public ulong Name { get; private set; }

	public static TextureChannel Deserialize(BinaryReader reader)
	{
		var tex = new TextureChannel();
		tex.Channel = reader.ReadUInt32();
		tex.Name = reader.ReadUInt64();
		return tex;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Channel);
		writer.Write(Name);
	}
}
