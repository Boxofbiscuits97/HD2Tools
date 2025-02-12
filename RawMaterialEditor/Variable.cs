using System.ComponentModel;

namespace RawMaterialEditor;

[TypeConverter(typeof(ExpandableObjectConverter))]
internal sealed class Variable
{
	public Klass Klass { get; }

	public uint Name { get; }

	public float[] Values { get; }

	[Browsable(false)]
	public uint Offset { get; }

	public Variable(uint name, uint offset, params float[] values)
	{
		if (values.Length == 0 || values.Length > 4)
			throw new ArgumentException("Values can only have 1-4 elements.", nameof(values));

		Klass = (Klass)(values.Length - 1);
		Name = name;
		Values = values;
		Offset = offset;
	}

	public override string ToString()
	{
		return $"{Klass} {Name}";
	}
}