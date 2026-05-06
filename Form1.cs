using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Diagnostics;

namespace DraftMaster
{
    public partial class Form1 : Form
    {
        private string currentProjectPath = "";
        private string currentDraftFile = "";
        private string currentOutliningFile = "";
        private bool outliningDataChanged = false;
        private bool draftDataChanged = false;
        private bool isDeleteLockEnabled = false;
        private string deleteLockPassword = "";
        public Form1()
        {
            InitializeComponent();
            InitializeStatusMenu();
            plottingDataGridView.MouseWheel += plottingDataGridView_MouseWheel;
            // 1. Enable Text Wrapping
            plottingDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 2. Let the Cell Grow as Needed (Wrap)
            // Change from 'None' to 'AllCells'. This forces the row height to expand 
            // to fit the wrapped text automatically.
            plottingDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            plottingDataGridView.AllowUserToResizeRows = true;

            // 3. Fill the Container
            // Change from 'None' to 'Fill'. This forces the columns to stretch evenly 
            // to take up all available horizontal space in the DataGridView.
            plottingDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            plottingDataGridView.AllowUserToResizeColumns = true;
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select where to create your new project";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Ask for project name
                    string projectName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter project name:",
                        "New Project",
                        "MyNovel");

                    if (string.IsNullOrWhiteSpace(projectName))
                        return;

                    // Create the project directory
                    string newProjectPath = Path.Combine(folderDialog.SelectedPath, projectName);

                    try
                    {
                        Directory.CreateDirectory(newProjectPath);
                        currentProjectPath = newProjectPath;
                        LoadProject();
                        MessageBox.Show("Project created successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error creating project: " + ex.Message);
                    }
                }
            }
        }

        private void SaveCurrentChapter()
        {
            // If no file is currently open, prompt for filename
            if (string.IsNullOrEmpty(currentDraftFile))
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.InitialDirectory = currentProjectPath;
                    saveDialog.Filter = "Markdown files (*.md)|*.md";
                    saveDialog.DefaultExt = "md";
                    saveDialog.Title = "Save Chapter As";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentDraftFile = saveDialog.FileName;
                    }
                    else
                    {
                        return; // User cancelled
                    }
                }
            }

            try
            {
                File.WriteAllText(currentDraftFile, draftingTextBox.Text);
                draftDataChanged = false;

                // Refresh the tree to show the new file
                LoadProject();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving chapter: " + ex.Message);
            }
        }

        private void SaveCurrentPlottingGrid()
        {
            // If no file is currently open, prompt for filename
            if (string.IsNullOrEmpty(currentOutliningFile))
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.InitialDirectory = currentProjectPath;
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.DefaultExt = "csv";
                    saveDialog.Title = "Save Grid As";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentOutliningFile = saveDialog.FileName;
                    }
                    else
                    {
                        return; // User cancelled
                    }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(currentOutliningFile))
                {
                    // Write headers with pipe delimiter
                    for (int i = 0; i < plottingDataGridView.Columns.Count; i++)
                    {
                        sw.Write(plottingDataGridView.Columns[i].HeaderText);
                        if (i < plottingDataGridView.Columns.Count - 1)
                            sw.Write("|");  // Changed from comma to pipe
                    }
                    sw.WriteLine();

                    // Write rows with pipe delimiter
                    foreach (DataGridViewRow row in plottingDataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        for (int i = 0; i < plottingDataGridView.Columns.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString() ?? "");
                            if (i < plottingDataGridView.Columns.Count - 1)
                                sw.Write("|");  // Changed from comma to pipe
                        }
                        sw.WriteLine();
                    }
                }
                outliningDataChanged = false;

                // Refresh the tree to show the new file
                LoadProject();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving plotting grid: " + ex.Message);
            }
        }

        private void LoadProject()
        {
            if (string.IsNullOrEmpty(currentProjectPath) || !Directory.Exists(currentProjectPath))
                return;

            // Load Drafting tree
            draftsTreeView.Nodes.Clear();
            TreeNode draftRoot = new TreeNode(Path.GetFileName(currentProjectPath));
            draftRoot.Tag = currentProjectPath;
            draftsTreeView.Nodes.Add(draftRoot);
            LoadMarkdownFiles(draftRoot, currentProjectPath);
            draftRoot.Expand();

            // Load Plotting tree
            plottingTreeView.Nodes.Clear();
            TreeNode plotRoot = new TreeNode(Path.GetFileName(currentProjectPath));
            plotRoot.Tag = currentProjectPath;
            plottingTreeView.Nodes.Add(plotRoot);
            LoadCSVFiles(plotRoot, currentProjectPath);
            plotRoot.Expand();

            this.Text = "DraftMaster - " + Path.GetFileName(currentProjectPath);

            RefreshTreeColors();
        }

        private void LoadMarkdownFiles(TreeNode parentNode, string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, "*.md"))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                    fileNode.Tag = file;
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading markdown files: " + ex.Message);
            }
        }

        private void LoadCSVFiles(TreeNode parentNode, string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, "*.csv"))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                    fileNode.Tag = file;
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV files: " + ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentChapter();
            SaveCurrentPlottingGrid();
            MessageBox.Show("All changes saved!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentPlottingGrid();
            MessageBox.Show("Outline saved");
        }

        private void saveDraftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentChapter();
            MessageBox.Show("Draft saved");
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select your project folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    currentProjectPath = folderDialog.SelectedPath;
                    LoadProject();
                    MessageBox.Show("Project loaded successfully!");
                }
            }
        }

        private void draftsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            {
                // 1. THE FIX: Force selection if Right-Clicked
                // This ensures the Context Menu knows which node you are talking about.
                if (e.Button == MouseButtons.Right)
                {
                    draftsTreeView.SelectedNode = e.Node;
                }

                // 2. Standard Logic (Left or Right click checks)
                if (e.Node.Tag == null) return;
                string path = e.Node.Tag.ToString();

                if (File.Exists(path) && path.EndsWith(".md"))
                {
                    // Set current file
                    currentDraftFile = path;

                    // Load the text (Only needed on Left Click usually, but harmless here)
                    // If you only want to load text on Left Click, wrap this in "if (e.Button == MouseButtons.Left)"
                    LoadDraftFile(path);
                }
            }
        }

        // 1. Initialize the Menu (Call this in your Constructor!)
        private void InitializeStatusMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem itemDraft = new ToolStripMenuItem("Drafting");
            ToolStripMenuItem itemEdit = new ToolStripMenuItem("In Dev Edits");
            ToolStripMenuItem itemCopy = new ToolStripMenuItem("In Copy Edits");
            ToolStripMenuItem itemDone = new ToolStripMenuItem("Complete");

            // Add click events
            itemDraft.Click += StatusItem_Click;
            itemEdit.Click += StatusItem_Click;
            itemCopy.Click += StatusItem_Click;
            itemDone.Click += StatusItem_Click;

            menu.Items.AddRange(new ToolStripItem[] { itemDraft, itemEdit, itemCopy, itemDone });

            // Attach to the TreeView
            draftsTreeView.ContextMenuStrip = menu;
        }

        // 2. The Click Handler for the Menu Items
        private void StatusItem_Click(object sender, EventArgs e)
        {
            // Ensure a node is actually selected
            if (draftsTreeView.SelectedNode == null || draftsTreeView.SelectedNode.Tag == null)
                return;

            string path = draftsTreeView.SelectedNode.Tag.ToString();
            string newStatus = ((ToolStripMenuItem)sender).Text;

            // Save to metadata.txt
            SaveDraftStatus(path, newStatus);

            // Update Visuals Immediately
            ColorNode(draftsTreeView.SelectedNode, newStatus);
        }

        // 3. Helper to paint a specific node based on status string
        private void ColorNode(TreeNode node, string status)
        {
            // Define your Status Colors here
            if (status == "Complete") node.ForeColor = Color.LimeGreen;
            else if (status == "In Dev Edits") node.ForeColor = Color.Orange;
            else if (status == "In Copy Edits") node.ForeColor = Color.DeepSkyBlue;
            else
            {
                // Default "Drafting" color depends on theme
                node.ForeColor = darkModeRadioBtn.Checked ? Color.White : Color.Black;
            }
        }

        // 4. Refresh All Nodes (Call this on LoadProject)
        private void RefreshTreeColors()
        {
            var statuses = GetAllStatuses();

            // We assume the first root node holds the files
            if (draftsTreeView.Nodes.Count > 0)
            {
                foreach (TreeNode node in draftsTreeView.Nodes[0].Nodes)
                {
                    if (node.Tag != null)
                    {
                        string filename = Path.GetFileName(node.Tag.ToString());

                        // If we have a status, color it. If not, default it.
                        if (statuses.ContainsKey(filename))
                        {
                            ColorNode(node, statuses[filename]);
                        }
                        else
                        {
                            // Reset to default theme color if no status exists
                            node.ForeColor = darkModeRadioBtn.Checked ? Color.White : Color.Black;
                        }
                    }
                }
            }
        }

        private void LoadDraftFile(string filePath)
        {
            try
            {
                currentDraftFile = filePath;
                draftingTextBox.Text = File.ReadAllText(filePath);
                draftDataChanged = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading chapter: " + ex.Message);
            }
        }

        private void plottingTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            string path = e.Node.Tag.ToString();

            // Only load if it's a file, not a directory
            if (File.Exists(path) && path.EndsWith(".csv"))
            {
                LoadCSVFile(path);
            }
        }

        private void LoadCSVFile(string filePath)
        {
            try
            {
                currentOutliningFile = filePath;
                plottingDataGridView.Rows.Clear();
                plottingDataGridView.Columns.Clear();

                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                    return;

                // Parse headers
                string[] headers = lines[0].Split('|');
                foreach (string header in headers)
                {
                    plottingDataGridView.Columns.Add(header, header);
                }

                // Parse data rows
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split('|');
                    plottingDataGridView.Rows.Add(values);
                }

                outliningDataChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV: " + ex.Message);
            }
        }

        private void newGridBtn_Click(object sender, EventArgs e)
        {
            // Clear existing grid
            plottingDataGridView.Rows.Clear();
            plottingDataGridView.Columns.Clear();

            // Add default 5 columns
            for (int i = 0; i < 5; i++)
            {
                plottingDataGridView.Columns.Add($"Column{i + 1}", $"Column {i + 1}");
            }

            // Clear current file reference (this is a NEW grid)
            currentOutliningFile = "";
            outliningDataChanged = true;

            MessageBox.Show("New grid created with 5 columns!\n\n" +
                            "• Double-click column headers to rename\n" +
                            "• Right-click column headers to add/delete columns\n" +
                            "• Start typing to add data");
        }

        private void addColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newColNum = plottingDataGridView.Columns.Count + 1;
            plottingDataGridView.Columns.Add($"Column{newColNum}", $"Column {newColNum}");
            outliningDataChanged = true;
        }

        private void deleteColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plottingDataGridView.Columns.Count <= 1)
            {
                MessageBox.Show("Cannot delete the last column!");
                return;
            }

            // Delete the last column
            plottingDataGridView.Columns.RemoveAt(plottingDataGridView.Columns.Count - 1);
            outliningDataChanged = true;
        }

        private void saveDraftBtn_Click(object sender, EventArgs e)
        {
            SaveCurrentChapter();
            MessageBox.Show("Draft saved");
        }

        // KEEP THIS: Used to read the file and color the tree
        private Dictionary<string, string> GetAllStatuses()
        {
            var statuses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (string.IsNullOrEmpty(currentProjectPath)) return statuses;
            string metadataPath = Path.Combine(currentProjectPath, "metadata.txt");

            if (File.Exists(metadataPath))
            {
                foreach (var line in File.ReadAllLines(metadataPath))
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        if (!string.IsNullOrEmpty(key)) statuses[key] = value;
                    }
                }
            }
            return statuses;
        }

        // UPDATE THIS: Removed the 'isLoadingStatus' check since we don't need it anymore
        private void SaveDraftStatus(string filePath, string status)
        {
            if (string.IsNullOrEmpty(currentProjectPath) || string.IsNullOrEmpty(filePath))
                return;

            string metadataPath = Path.Combine(currentProjectPath, "metadata.txt");
            string fileName = Path.GetFileName(filePath);

            // Get current statuses
            var statuses = GetAllStatuses();

            // Update the specific file
            statuses[fileName] = status;

            // Write back to file
            var lines = statuses.Select(kvp => $"{kvp.Key}|{kvp.Value}");
            File.WriteAllLines(metadataPath, lines);
        }

        private void saveOutlineBtn_Click(object sender, EventArgs e)
        {
            SaveCurrentPlottingGrid();
            MessageBox.Show("Outline saved");
        }
        private void deleteLockButton_Click(object sender, EventArgs e)
        {
            if (!isDeleteLockEnabled)
            {
                // Turn lock ON
                deleteLockPassword = GenerateRandomPassword();

                MessageBox.Show($"Delete Lock is now ENABLED.\n\n" +
                               $"Your password is: {deleteLockPassword}\n\n" +
                               $"WRITE THIS DOWN! You'll need it to unlock.\n" +
                               $"This password will be lost when you close the program.",
                               "Delete Lock Enabled",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                isDeleteLockEnabled = true;
                deleteLockButton.Text = "Delete Lock ON";
                deleteLockButton.BackColor = Color.Salmon;
            }
            else
            {
                // Turn lock OFF - prompt for password
                string enteredPassword = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter the delete lock password:",
                    "Unlock Delete Lock",
                    "");

                if (enteredPassword == deleteLockPassword)
                {
                    isDeleteLockEnabled = false;
                    deleteLockPassword = "";
                    deleteLockButton.Text = "Delete Lock OFF";
                    deleteLockButton.BackColor = SystemColors.Control;
                    MessageBox.Show("Delete Lock disabled!");
                }
                else
                {
                    MessageBox.Show("Incorrect password! Lock remains enabled.",
                                  "Access Denied",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
            Random random = new Random();
            char[] password = new char[8];

            for (int i = 0; i < 8; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            return new string(password);
        }

        private void draftingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isDeleteLockEnabled)
                return;

            // Block Delete key
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            // Block Backspace key
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            // Block Ctrl+X (Cut)
            if (e.Control && e.KeyCode == Keys.X)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void lightModeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            bool isDarkMode = darkModeRadioBtn.Checked;

            // 1. Define the Palette
            Color backColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            Color foreColor = isDarkMode ? Color.White : SystemColors.ControlText;
            Color controlBack = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Window;

            // 2. Form Basics
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            // 3. DataGridView Theme (Specific overrides)
            plottingDataGridView.BackgroundColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.AppWorkspace;
            plottingDataGridView.RowsDefaultCellStyle.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Window;
            plottingDataGridView.RowsDefaultCellStyle.ForeColor = isDarkMode ? Color.White : SystemColors.ControlText;
            plottingDataGridView.EnableHeadersVisualStyles = !isDarkMode;

            if (isDarkMode)
            {
                plottingDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
                plottingDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                plottingDataGridView.GridColor = Color.FromArgb(80, 80, 80);
            }

            // 4. THE BRUTE FORCE FIX: Target the RichTextBox directly
            // Since it's a RichTextBox, we set it here to be 100% sure.
            if (draftingTextBox != null)
            {
                draftingTextBox.BackColor = controlBack;
                draftingTextBox.ForeColor = foreColor;
                draftingTextBox.BorderStyle = isDarkMode ? BorderStyle.None : BorderStyle.Fixed3D;
            }

            // 5. Run the Global Deep-Search
            ThemeControls(this.Controls, isDarkMode, backColor, foreColor, controlBack);

            RefreshTreeColors();
        }

        private void ThemeControls(Control.ControlCollection controls, bool isDarkMode, Color backColor, Color foreColor, Color controlBack)
        {
            foreach (Control c in controls)
            {
                // DRILL DOWN: If it's a container (Panel, GroupBox, TabPage, etc.)
                if (c.HasChildren)
                {
                    ThemeControls(c.Controls, isDarkMode, backColor, foreColor, controlBack);
                }

                // SPECIAL CASE: SplitContainer panels are notoriously hard to reach
                if (c is SplitContainer sc)
                {
                    ThemeControls(sc.Panel1.Controls, isDarkMode, backColor, foreColor, controlBack);
                    ThemeControls(sc.Panel2.Controls, isDarkMode, backColor, foreColor, controlBack);
                }

                // APPLY COLORS based on type
                if (c is TextBox || c is RichTextBox || c is TreeView)
                {
                    c.BackColor = controlBack;
                    c.ForeColor = foreColor;
                }
                else if (c is Button btn)
                {
                    btn.BackColor = isDarkMode ? Color.FromArgb(63, 63, 70) : SystemColors.Control;
                    btn.ForeColor = foreColor;
                    btn.FlatStyle = isDarkMode ? FlatStyle.Flat : FlatStyle.Standard;
                }
                else if (c is Label || c is RadioButton || c is CheckBox || c is TabPage)
                {
                    c.ForeColor = foreColor;
                    // TabPages and Labels need the main backColor, not the input backColor
                    c.BackColor = backColor;
                }
            }
        }

        private void plottingDataGridView_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if CTRL key is held down
            if (Control.ModifierKeys == Keys.Control)
            {
                // Prevent the grid from scrolling while we zoom
                if (e is HandledMouseEventArgs he) he.Handled = true;

                // Calculate new font size
                Font currentFont = plottingDataGridView.DefaultCellStyle.Font;
                float newSize = currentFont.Size;

                // Scroll Up = Zoom In (+1), Scroll Down = Zoom Out (-1)
                if (e.Delta > 0) newSize += 1f;
                else newSize -= 1f;

                // Limit the zoom (Min 6pt, Max 36pt) to prevent crashes
                if (newSize < 6) newSize = 6;
                if (newSize > 36) newSize = 36;

                // Apply the new font size
                // We update both the Cells and the Headers so they match
                Font newFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
                plottingDataGridView.DefaultCellStyle.Font = newFont;
                plottingDataGridView.ColumnHeadersDefaultCellStyle.Font = newFont;

                // Auto-resize rows so the taller text doesn't get cut off
                plottingDataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
        }

        private void darkModeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Force a Save of whatever is currently open
            SaveCurrentChapter();
            SaveCurrentPlottingGrid();

            // 2. Run the export
            ExportProjectToZip();
        }

        private void ExportProjectToZip()
        {
            if (string.IsNullOrEmpty(currentProjectPath) || !Directory.Exists(currentProjectPath))
            {
                MessageBox.Show("Please open a project first.");
                return;
            }

            try
            {
                // Setup Paths
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HHmm");
                string projectName = Path.GetFileName(currentProjectPath);
                string zipFileName = $"{projectName}_Export_{timestamp}.zip";
                string zipPath = Path.Combine(currentProjectPath, zipFileName);

                // Create a Temp Directory to gather files
                // (We do this to avoid zipping the zip file itself or locking files)
                string tempPath = Path.Combine(Path.GetTempPath(), "DraftMaster_Export_" + Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempPath);

                // Define what extensions we want to keep
                var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".md", ".csv", ".txt"
        };

                // Copy files to Temp
                foreach (string file in Directory.GetFiles(currentProjectPath))
                {
                    string ext = Path.GetExtension(file);
                    if (allowedExtensions.Contains(ext))
                    {
                        string destFile = Path.Combine(tempPath, Path.GetFileName(file));
                        File.Copy(file, destFile, true);
                    }
                }

                // Create the Zip
                if (File.Exists(zipPath)) File.Delete(zipPath); // Overwrite if exists (unlikely with timestamp)
                ZipFile.CreateFromDirectory(tempPath, zipPath);

                // Cleanup
                Directory.Delete(tempPath, true);

                // Success Message
                MessageBox.Show($"Project exported successfully!\n\nLocation: {zipPath}", "Export Complete");

                // Optional: Highlight the new file in Windows Explorer
                string argument = "/select, \"" + zipPath + "\"";
                Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting project: " + ex.Message);
            }
        }
    }

}
