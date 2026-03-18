using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace FrequencyDictionaryTreeApp.Presentation.WinForms;

partial class MainForm : System.Windows.Forms.Form
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        splitContainer1 = new SplitContainer();
        txtInput = new TextBox();
        lstResult = new ListBox();
        groupSettings = new GroupBox();
        rbAlphabetical = new RadioButton();
        rbFrequency = new RadioButton();
        btnBuild = new Button();
        btnClear = new Button();
        lblStats = new Label();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        groupSettings.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(txtInput);
        splitContainer1.Panel1.Padding = new Padding(8);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(lstResult);
        splitContainer1.Panel2.Controls.Add(groupSettings);
        splitContainer1.Panel2.Padding = new Padding(8);
        splitContainer1.Size = new Size(984, 611);
        splitContainer1.SplitterDistance = 578;
        splitContainer1.TabIndex = 0;
        // 
        // txtInput
        // 
        txtInput.Dock = DockStyle.Fill;
        txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
        txtInput.Location = new Point(8, 8);
        txtInput.Multiline = true;
        txtInput.Name = "txtInput";
        txtInput.ScrollBars = ScrollBars.Vertical;
        txtInput.Size = new Size(562, 595);
        txtInput.TabIndex = 0;
        // 
        // lstResult
        // 
        lstResult.Dock = DockStyle.Fill;
        lstResult.Font = new System.Drawing.Font("Consolas", 11F);
        lstResult.Location = new Point(8, 148);
        lstResult.Name = "lstResult";
        lstResult.Size = new Size(386, 455);
        lstResult.TabIndex = 0;
        lstResult.DoubleClick += lstResult_DoubleClick;
        // 
        // groupSettings
        // 
        groupSettings.Controls.Add(rbAlphabetical);
        groupSettings.Controls.Add(rbFrequency);
        groupSettings.Controls.Add(btnBuild);
        groupSettings.Controls.Add(btnClear);
        groupSettings.Controls.Add(lblStats);
        groupSettings.Dock = DockStyle.Top;
        groupSettings.Location = new Point(8, 8);
        groupSettings.Name = "groupSettings";
        groupSettings.Size = new Size(386, 140);
        groupSettings.TabIndex = 1;
        groupSettings.TabStop = false;
        groupSettings.Text = "Действия";
        // 
        // rbAlphabetical
        // 
        rbAlphabetical.Checked = true;
        rbAlphabetical.Location = new Point(15, 25);
        rbAlphabetical.Name = "rbAlphabetical";
        rbAlphabetical.Size = new Size(104, 24);
        rbAlphabetical.TabIndex = 0;
        rbAlphabetical.TabStop = true;
        rbAlphabetical.Text = "По алфавиту";
        // 
        // rbFrequency
        // 
        rbFrequency.Location = new Point(15, 50);
        rbFrequency.Name = "rbFrequency";
        rbFrequency.Size = new Size(104, 24);
        rbFrequency.TabIndex = 1;
        rbFrequency.Text = "По частоте";
        // 
        // btnBuild
        // 
        btnBuild.Location = new Point(15, 80);
        btnBuild.Name = "btnBuild";
        btnBuild.Size = new Size(140, 35);
        btnBuild.TabIndex = 2;
        btnBuild.Text = "Построить";
        btnBuild.Click += btnBuild_Click;
        // 
        // btnClear
        // 
        btnClear.Location = new Point(165, 80);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(120, 35);
        btnClear.TabIndex = 3;
        btnClear.Text = "Очистить";
        btnClear.Click += btnClear_Click;
        // 
        // lblStats
        // 
        lblStats.AutoSize = true;
        lblStats.Location = new Point(260, 30);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(115, 15);
        lblStats.TabIndex = 4;
        lblStats.Text = "Уникальных слов: 0";
        // 
        // MainForm
        // 
        ClientSize = new Size(984, 611);
        Controls.Add(splitContainer1);
        MinimumSize = new Size(750, 500);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Частотный словарь";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        groupSettings.ResumeLayout(false);
        groupSettings.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private TextBox txtInput;
    private TableLayoutPanel tableLayoutPanel1;
    private GroupBox groupSettings;
    private RadioButton rbAlphabetical;
    private RadioButton rbFrequency;
    private Button btnBuild;
    private Button btnClear;
    private Label lblStats;
    private ListBox lstResult;
}