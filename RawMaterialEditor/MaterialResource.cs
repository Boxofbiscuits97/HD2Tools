using System.ComponentModel;

namespace RawMaterialEditor;

internal sealed class MaterialResource : IBinarySerializable<MaterialResource>
{
	[Category("Header")]
	[Description("The version of the material.")]
	public uint Version { get; private set; }

	[Category("Header")]
	[Description("The type of material. If it's a set or a single one.")]
	public Type Type { get; private set; }

	[Category("Resources")]
	[Description("The templates for the material resource.")]
	public MaterialTemplate Templates { get; private set; }

	private uint _materialOffset;
	private uint _materialSize;
	private uint _shaderOffset;
	private uint _shaderSize;

#pragma warning disable CS8618
	private MaterialResource()
#pragma warning restore CS8618
	{ }

	public static MaterialResource Deserialize(BinaryReader reader)
	{
		var mat = new MaterialResource();
		mat.Version = reader.ReadUInt32();
		mat.Type = (Type)reader.ReadUInt32();
		mat._materialOffset = reader.ReadUInt32();
		mat._materialSize = reader.ReadUInt32();
		mat._shaderOffset = reader.ReadUInt32();
		mat._shaderSize = reader.ReadUInt32();
		mat.Templates = MaterialTemplate.Deserialize(reader);
		return mat;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Version);
		writer.Write((uint)Type);
		writer.Write(_materialOffset);
		writer.Write(_materialSize);
		writer.Write(_shaderOffset);
		writer.Write(_shaderSize);
		Templates.Serialize(writer);
	}
}
