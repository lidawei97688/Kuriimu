﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kontract.Interface;
using Kontract;
using Kuriimu.Properties;

namespace Kuriimu
{
    public partial class Find : Form
    {
        public IEnumerable<TextEntry> Entries { get; set; }
        public IGameHandler Handler { get; set; }
        public TextEntry Selected { get; private set; }
        public TextEntry Current { get; set; }
        public bool Replace { get; set; }
        public bool Replaced { get; private set; }

        public Find()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            Icon = !Replace ? Resources.find : Resources.replace;
            Text = !Replace ? "查找" : "替换";
            tabFindReplace.SelectedIndex = !Replace ? 0 : 1;
            AcceptButton = !Replace ? btnFindText : btnReplaceText;
            CancelButton = !Replace ? btnCancel : btnCancelReplace;

            // Find
            txtFindText.Text = Settings.Default.FindWhat;
            chkMatchCase.Checked = Settings.Default.FindMatchCase;

            // Replace
            txtFindTextReplace.Text = Settings.Default.FindWhat;
            txtReplaceText.Text = Settings.Default.ReplaceWith;
            btnReplaceText.Text = Settings.Default.ReplaceAll ? "全部替换" : "替换";
            chkMatchCaseReplace.Checked = Settings.Default.FindMatchCase;
            chkReplaceAll.Checked = Settings.Default.ReplaceAll;

            if (!Replace)
                DoFind();

            if (lstResults.Items.Count > Settings.Default.FindSelectedIndex)
                lstResults.SelectedIndex = Settings.Default.FindSelectedIndex;
        }

        private void tabFindReplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            Replace = tabFindReplace.SelectedIndex != 0;
            frmFind_Load(this, EventArgs.Empty);
            if (!Replace)
            {
                txtFindText.Focus();
                txtFindText.SelectAll();
            }
            else
            {
                txtFindTextReplace.Focus();
                txtFindTextReplace.SelectAll();
            }
        }

        private void btnFindText_Click(object sender, EventArgs e)
        {
            if (txtFindText.Focused)
                DoFind();
            //else
            //    lstResults_DoubleClick(lstResults, EventArgs.Empty);

            if (lstResults.Items.Count == 0)
                MessageBox.Show("未找到 \"" + txtFindText.Text + "\".", "查找", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoFind()
        {
            lstResults.BeginUpdate();

            lstResults.Items.Clear();
            if (txtFindText.Text.Trim() != string.Empty && Entries != null)
            {
                foreach (var entry in Entries)
                {
                    var edited = Handler.GetKuriimuString(entry.EditedText);
                    var original = Handler.GetKuriimuString(entry.OriginalText);

                    if (chkMatchCase.Checked)
                    {
                        if (edited.Contains(txtFindText.Text) || original.Contains(txtFindText.Text) || entry.Name.Contains(txtFindText.Text))
                            lstResults.Items.Add(new ListItem(entry.ToString(), entry));
                    }
                    else
                    {
                        if (edited.ToLower().Contains(txtFindText.Text.ToLower()) || original.ToLower().Contains(txtFindText.Text.ToLower()) || entry.Name.ToLower().Contains(txtFindText.Text.ToLower()))
                            lstResults.Items.Add(new ListItem(entry.ToString(), entry));
                    }

                    foreach (var subEntry in entry.SubEntries)
                    {
                        var subEdited = Handler.GetKuriimuString(subEntry.EditedText);
                        var subOriginal = Handler.GetKuriimuString(subEntry.OriginalText);

                        if (chkMatchCase.Checked)
                        {
                            if (subEdited.Contains(txtFindText.Text) || subOriginal.Contains(txtFindText.Text) || subEntry.Name.Contains(txtFindText.Text))
                                lstResults.Items.Add(new ListItem(entry + "/" + subEntry, subEntry));
                        }
                        else
                        {
                            if (subEdited.ToLower().Contains(txtFindText.Text.ToLower()) || subOriginal.ToLower().Contains(txtFindText.Text.ToLower()) || subEntry.Name.ToLower().Contains(txtFindText.Text.ToLower()))
                                lstResults.Items.Add(new ListItem(entry + "/" + subEntry, subEntry));
                        }
                    }
                }
            }
            lstResults.EndUpdate();

            tslResultCount.Text = lstResults.Items.Count > 0 ? "找到 " + lstResults.Items.Count + " 个匹配项" : string.Empty;
        }

        private void btnReplaceText_Click(object sender, EventArgs e)
        {
            DoReplace();

            if (lstResultsReplace.Items.Count == 0)
                MessageBox.Show("未找到 \"" + txtFindTextReplace.Text + "\".", "替换", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoReplace()
        {
            lstResultsReplace.BeginUpdate();

            lstResultsReplace.Items.Clear();
            if (txtFindTextReplace.Text.Trim() != string.Empty)
            {
                if (Settings.Default.ReplaceAll && Entries != null)
                {
                    foreach (var entry in Entries)
                    {
                        var edited = Handler.GetKuriimuString(entry.EditedText);

                        if (chkMatchCaseReplace.Checked)
                        {
                            if (edited.Contains(txtFindTextReplace.Text))
                            {
                                entry.EditedText = Handler.GetRawString(Regex.Replace(edited, txtFindTextReplace.Text, txtReplaceText.Text));
                                lstResultsReplace.Items.Add(new ListItem(entry.ToString(), entry));
                            }
                        }
                        else
                        {
                            if (edited.ToLower().Contains(txtFindText.Text.ToLower()))
                            {
                                entry.EditedText = Handler.GetRawString(Regex.Replace(edited, txtFindTextReplace.Text, txtReplaceText.Text, RegexOptions.IgnoreCase));
                                lstResultsReplace.Items.Add(new ListItem(entry.ToString(), entry));
                            }
                        }

                        foreach (var subEntry in entry.SubEntries)
                        {
                            var subEdited = Handler.GetKuriimuString(subEntry.EditedText);

                            if (chkMatchCaseReplace.Checked)
                            {
                                if (subEdited.Contains(txtFindTextReplace.Text))
                                {
                                    subEntry.EditedText = Handler.GetRawString(Regex.Replace(subEdited, txtFindTextReplace.Text, txtReplaceText.Text));
                                    lstResultsReplace.Items.Add(new ListItem(entry + "/" + subEntry, subEntry));
                                }
                            }
                            else
                            {
                                if (subEdited.ToLower().Contains(txtFindText.Text.ToLower()))
                                {
                                    subEntry.EditedText = Handler.GetRawString(Regex.Replace(subEdited, txtFindTextReplace.Text, txtReplaceText.Text, RegexOptions.IgnoreCase));
                                    lstResultsReplace.Items.Add(new ListItem(entry + "/" + subEntry, subEntry));
                                }
                            }
                        }
                    }
                }
                else if (!Settings.Default.ReplaceAll && Current != null)
                {
                    var current = Handler.GetKuriimuString(Current.EditedText);

                    if (chkMatchCaseReplace.Checked)
                    {
                        if (current.Contains(txtFindTextReplace.Text))
                        {
                            Current.EditedText = Handler.GetRawString(Regex.Replace(current, txtFindTextReplace.Text, txtReplaceText.Text));
                            lstResultsReplace.Items.Add(new ListItem(Current.ToString(), Current));
                        }
                    }
                    else
                    {
                        if (current.ToLower().Contains(txtFindText.Text.ToLower()))
                        {
                            Current.EditedText = Handler.GetRawString(Regex.Replace(current, txtFindTextReplace.Text, txtReplaceText.Text, RegexOptions.IgnoreCase));
                            lstResultsReplace.Items.Add(new ListItem(Current.ToString(), Current));
                        }
                    }
                }
            }
            lstResultsReplace.EndUpdate();

            tslResultCount.Text = lstResultsReplace.Items.Count > 0 ? "替换了 " + lstResultsReplace.Items.Count + (lstResultsReplace.Items.Count == 1 ? " 个条目中的字符串" : " 条目.") : string.Empty;

            if (!Replaced)
                Replaced = lstResultsReplace.Items.Count > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtFindText_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.FindWhat = ((TextBox)sender).Text;
            Settings.Default.Save();
        }

        private void txtReplaceText_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ReplaceWith = ((TextBox)sender).Text;
            Settings.Default.Save();
        }

        private void chkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.FindMatchCase = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void chkReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            btnReplaceText.Text = chkReplaceAll.Checked ? "全部替换" : "替换";
            Settings.Default.ReplaceAll = chkReplaceAll.Checked;
            Settings.Default.Save();
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.Items.Count <= 0 || lstResults.SelectedIndex < 0) return;
            Selected = (TextEntry)((ListItem)lstResults.SelectedItem).Value;
            DialogResult = DialogResult.OK;
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.FindSelectedIndex = lstResults.SelectedIndex;
            Settings.Default.Save();
        }

        private void lstResultsReplace_DoubleClick(object sender, EventArgs e)
        {
            if (lstResultsReplace.Items.Count <= 0 || lstResultsReplace.SelectedIndex < 0) return;
            Selected = (TextEntry)((ListItem)lstResultsReplace.SelectedItem).Value;
            DialogResult = DialogResult.OK;
        }
    }
}