namespace WinFormsHomeWork2
{

    public partial class Form1 : Form
    {
        private string ProjectPath;
        public Form1()
        {
            InitializeComponent();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = "NewTextDocument";
            var selectFileLocationFolderDialog = new FolderBrowserDialog();

            if (selectFileLocationFolderDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectPath = selectFileLocationFolderDialog.SelectedPath;
                File.Create(ProjectPath + $"\\{fileName}.txt");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files |*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var result = openFileDialog.FileName;
                Notepad.Text = File.ReadAllText(result);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files |*.txt";
                saveFileDialog.ShowDialog();

                return;
            }

            File.WriteAllText(ProjectPath, Notepad.Text);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath))
            {
                DialogResult result = MessageBox.Show("Your text isn't saved in file, are you sure you wanna exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) Application.Exit();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            var result = colorDialog.Color;
            Notepad.ForeColor = result;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            var result = fontDialog.Font;
            Notepad.Font = result;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name: Alina\nOrucova: Orucova\nAge: 15", "Info", MessageBoxButtons.OK);
        }

        private void hotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ctrl + N - Create new file\nCtrl + O - Open File\nCtrl + S - Save File\nCtrl + P - Print\nCtrl + E - Exit\nCtrl + F - Open Font\nCtrl + C - Open Color", "HotKey Help",
                MessageBoxButtons.OK);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NotePad\nDate: 14.04.2024", "About", MessageBoxButtons.OK);
        }

    }
}


