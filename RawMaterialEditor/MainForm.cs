namespace RawMaterialEditor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            using var stream = File.OpenRead(openFileDialog.FileName);
            using var reader = new BinaryReader(stream);
            propertyGrid.SelectedObject = MaterialResource.Deserialize(reader);
            btnSave.Enabled = true;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            using var stream = File.OpenWrite(saveFileDialog.FileName);
            using var writer = new BinaryWriter(stream);
            ((MaterialResource)propertyGrid.SelectedObject!).Serialize(writer);
        }
    }

    private void propertyGrid_Click(object sender, EventArgs e)
    {

    }
}
