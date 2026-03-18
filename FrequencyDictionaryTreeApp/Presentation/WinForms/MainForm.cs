using FrequencyDictionaryApp.Core.Enums;
using FrequencyDictionaryApp.Core.Interfaces;
using FrequencyDictionaryApp.Infrastructure.Factories;
using System;
using System.Windows.Forms;
using FrequencyDictionaryApp.Core.Enums;
using FrequencyDictionaryApp.Core.Interfaces;
using FrequencyDictionaryApp.Infrastructure.Factories;
using System;
using System.Windows.Forms;

namespace FrequencyDictionaryTreeApp.Presentation.WinForms;

public partial class MainForm : Form
{
    private readonly IFrequencyDictionary _dictionary = FrequencyDictionaryFactory.CreateTreeBased();

    public MainForm()
    {
        InitializeComponent();
        txtInput.Focus();
    }

    private void btnBuild_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtInput.Text))
        {
            MessageBox.Show("Введите текст для анализа.", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        lstResult.Items.Clear();

        _dictionary.BuildFrom(txtInput.Text);

        var mode = rbAlphabetical.Checked
            ? SortMode.Alphabetical
            : SortMode.FrequencyDescending;

        var lines = _dictionary.GetFormattedLines(mode);

        lstResult.Items.AddRange(lines.ToArray());

        lblStats.Text = $"Уникальных основ слов: {_dictionary.UniqueWordCount}";
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtInput.Clear();
        lstResult.Items.Clear();
        lblStats.Text = "Уникальных основ слов: 0";
        _dictionary.Clear();
        txtInput.Focus();
    }

    private void lstResult_DoubleClick(object sender, EventArgs e)
    {
        if (lstResult.SelectedItem != null)
            Clipboard.SetText(lstResult.SelectedItem.ToString()!);
    }
}