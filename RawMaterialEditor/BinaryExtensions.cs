namespace RawMaterialEditor;

internal static class BinaryExtensions
{
	public static void Skip(this BinaryReader reader, long bytes)
	{
		reader.BaseStream.Seek(bytes, SeekOrigin.Current);
	}

	public static void Skip(this BinaryWriter writer, long bytes)
	{
		writer.BaseStream.Seek(bytes, SeekOrigin.Current);
	}
}