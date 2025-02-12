// Ignore Spelling: Deserialize

using System.ComponentModel;

namespace RawMaterialEditor;

[TypeConverter(typeof(ExpandableObjectConverter))]
internal sealed class MaterialTemplate : IBinarySerializable<MaterialTemplate>
{
	public ulong Name { get; private set; }

#pragma warning disable CS8618
	[TypeConverter(typeof(ArrayConverter))]
	public IReadOnlyList<TextureChannel> Channels { get; private set; }

	[TypeConverter(typeof(ArrayConverter))]
	public IReadOnlyList<Variable> Variables { get; private set; }
#pragma warning restore CS8618

	private uint _numChannels;
	private uint _numVariables;
	private uint _variableDataSize;

	public static MaterialTemplate Deserialize(BinaryReader reader)
	{
		var temp = new MaterialTemplate();
		temp.Name = reader.ReadUInt64();
		reader.Skip(32);
		temp._numChannels = reader.ReadUInt32();
		reader.Skip(36);
		temp._numVariables = reader.ReadUInt32();
		reader.Skip(12);
		temp._variableDataSize = reader.ReadUInt32();
		reader.Skip(12);

		var channels = new TextureChannel[temp._numChannels];
		for (int i = 0; i < temp._numChannels; i++)
			channels[i] = TextureChannel.Deserialize(reader);
		temp.Channels = channels;

		var reflection = new VariableReflection[temp._numVariables];
		for (int i = 0; i < temp._numVariables; i++)
			reflection[i] = VariableReflection.Deserialize(reader);

		var pos = reader.BaseStream.Position;
		var variables = new Variable[temp._numVariables];
		for (int i = 0; i < temp._numVariables; i++)
		{
			var reflect = reflection[i];
			reader.BaseStream.Seek(pos + reflect.Offset, SeekOrigin.Begin);
			variables[i] = reflect.Klass switch
			{
				Klass.Scalar => new Variable(reflect.Name, reflect.Offset, reader.ReadSingle()),
				Klass.Vector2 => new Variable(reflect.Name, reflect.Offset, reader.ReadSingle(), reader.ReadSingle()),
				Klass.Vector3 => new Variable(reflect.Name, reflect.Offset, reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()),
				Klass.Vector4 => new Variable(reflect.Name, reflect.Offset, reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()),
				_ => throw new Exception("Invalid variable class!")
			};
		}
		temp.Variables = variables;

		return temp;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Name);
		writer.Skip(32);
		writer.Write(_numChannels);
		writer.Skip(36);
		writer.Write(_numVariables);
		writer.Skip(12);
		writer.Write(_variableDataSize);
		writer.Skip(12);

		foreach (var channel in Channels)
			channel.Serialize(writer);

		for (int i = 0; i < _numVariables; i++)
		{
			var variable = new VariableReflection
			{
				Klass = Variables[i].Klass,
				Elements = 0,
				Name = Variables[i].Name,
				Offset = Variables[i].Offset,
				ElementStride = 0
			};
			variable.Serialize(writer);
		}

		var pos = writer.BaseStream.Position;
		foreach (var variable in Variables)
		{
			writer.BaseStream.Seek(pos + variable.Offset, SeekOrigin.Begin);
			foreach (var f in variable.Values)
				writer.Write(f);
		}
	}
}
