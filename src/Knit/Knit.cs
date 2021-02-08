﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knit
{
    public partial class frmMain : Form
    {
        private bool Patching { get; set; }
        private bool Cancelled { get; set; }
        private string BaseDirectory { get; set; }
        private string MetaDirectory { get; set; }
        private string ExitButtonText { get; set; }

        private Image ProgressIcon { get; set; }
        private bool MusicOn { get; set; }
        private string MusicPath { get; set; }
        private Image MusicOnIcon { get; set; }
        private Image MusicOffIcon { get; set; }

        private PictureBox picProgressAnimation { get; set; } = new PictureBox();
        WMPLib.WindowsMediaPlayer MediaPlayer = new WMPLib.WindowsMediaPlayer();

        private Meta Meta { get; set; } = new Meta();

        public frmMain()
        {
            InitializeComponent();

            DoubleBuffer(this, true);
            DoubleBuffer(pnlMain, true);
            DoubleBuffer(picProgressAnimation, true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Initialize
            BaseDirectory = "打补丁";
            MetaDirectory = Path.Combine(BaseDirectory, "meta");

            LoadMeta();
            UpdateForm();
            UpdateMusic();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MediaPlayer.controls.stop();
        }

        private void LoadMeta()
        {
            // Meta
            Meta = Meta.Load(Path.Combine(MetaDirectory, "meta.xml"));
            var background = new Bitmap(Path.Combine(MetaDirectory, Meta.Background));
            var icon = new Icon(Path.Combine(MetaDirectory, Meta.Icon));
            var animPath = Path.Combine(MetaDirectory, Meta.Layout.ProgressAnimation.Image);
            var tt = new ToolTip();

            // Title
            var title = new List<string>();
            if (Meta.Title.Trim() != string.Empty) title.Add(Meta.Title.Trim());
            if (Meta.Author.Trim() != string.Empty) title.Add(Meta.Author.Trim());
            if (Meta.Version.Trim() != string.Empty) title.Add(Meta.Version.Trim());
            Text = string.Join(" - ", title);

            Icon = icon;
            ClientSize = background.Size;
            BackgroundImage = background;

            // Progress Bar
            prgProgress.Location = Meta.Layout.ProgressBar.Location;
            prgProgress.Size = Meta.Layout.ProgressBar.Size;

            // Progress Animation
            if (Meta.Layout.ProgressAnimation.Image != string.Empty && File.Exists(animPath))
            {
                pnlMain.Controls.Add(picProgressAnimation);
                picProgressAnimation.Image = Image.FromFile(animPath);
                picProgressAnimation.SetBounds(Meta.Layout.ProgressAnimation.X, Meta.Layout.ProgressAnimation.Y, picProgressAnimation.Image.Width, picProgressAnimation.Image.Height);
            }

            // Patch Button
            btnPatch.Text = Meta.Layout.PatchButton.Text;
            btnPatch.Location = Meta.Layout.PatchButton.Location;
            btnPatch.Size = Meta.Layout.PatchButton.Size;

            // Exit Button
            ExitButtonText = Meta.Layout.ExitButton.Text;
            btnExit.Text = Meta.Layout.ExitButton.Text;
            btnExit.Location = Meta.Layout.ExitButton.Location;
            btnExit.Size = Meta.Layout.ExitButton.Size;

            // Music
            MusicOn = true;
            MusicPath = Path.Combine(MetaDirectory, Meta.Music);
            var onPath = Path.Combine(MetaDirectory, Meta.Layout.MusicButton.On ?? "");
            var offPath = Path.Combine(MetaDirectory, Meta.Layout.MusicButton.Off ?? "");
            if (File.Exists(onPath))
                MusicOnIcon = Image.FromFile(onPath);
            if (File.Exists(offPath))
                MusicOffIcon = Image.FromFile(offPath);
            btnMusic.Text = Meta.Layout.MusicButton.Text;
            btnMusic.Location = Meta.Layout.MusicButton.Location;
            btnMusic.Size = Meta.Layout.MusicButton.Size;
            btnMusic.Visible = !string.IsNullOrWhiteSpace(MusicPath);

            // About
            var iconPath = Path.Combine(MetaDirectory, Meta.Layout.AboutButton.Icon ?? "");
            if (File.Exists(iconPath))
                btnAbout.Image = Image.FromFile(iconPath);
            btnAbout.Text = Meta.Layout.AboutButton.Text;
            btnAbout.Location = Meta.Layout.AboutButton.Location;
            btnAbout.Size = Meta.Layout.AboutButton.Size;
            tt.SetToolTip(btnAbout, "关于");

            // Website
            iconPath = Path.Combine(MetaDirectory, Meta.Layout.WebsiteButton.Icon ?? "");
            if (File.Exists(iconPath))
                btnWebsite.Image = Image.FromFile(iconPath);
            btnWebsite.Text = Meta.Layout.WebsiteButton.Text;
            btnWebsite.Location = Meta.Layout.WebsiteButton.Location;
            btnWebsite.Size = Meta.Layout.WebsiteButton.Size;
            btnWebsite.Visible = !string.IsNullOrWhiteSpace(Meta.Website) && Regex.IsMatch(Meta.Website, @"^https?://");
            tt.SetToolTip(btnWebsite, $"网站: {Meta.Website}");

            // Status Bar
            txtStatus.ForeColor = Meta.Layout.StatusTextBox.Color;
            txtStatus.BorderStyle = Meta.Layout.StatusTextBox.Border;
            txtStatus.Location = Meta.Layout.StatusTextBox.Location;
            txtStatus.Size = Meta.Layout.StatusTextBox.Size;
            txtStatus.BackColor = Meta.Layout.StatusTextBox.BackColor;
        }

        private void UpdateForm()
        {
            btnPatch.Enabled = !Patching;
            btnExit.Text = !Patching ? ExitButtonText : "取消";
            btnExit.Enabled = true;
        }

        private void UpdateMusic()
        {
            btnMusic.Image = MusicOn ? MusicOnIcon : MusicOffIcon;
            new ToolTip().SetToolTip(btnMusic, MusicOn ? "音乐关闭" : "音乐开启");

            if (!File.Exists(MusicPath)) return;
            MediaPlayer.URL = MusicPath;
            MediaPlayer.settings.volume = Math.Min(Math.Max(0, Meta.Volume), 100);
            MediaPlayer.settings.setMode("循环", true);

            try
            {
                if (MusicOn)
                    MediaPlayer.controls.play();
                else if (!MusicOn)
                    MediaPlayer.controls.stop();
            }
            catch (Exception) { }
        }

        private void UpdateProgressAnimation()
        {
            var ratio = (double)prgProgress.Value / Math.Max(prgProgress.Maximum, 1);
            var nx = Meta.Layout.ProgressAnimation.X + (Meta.Layout.ProgressAnimation.DX - Meta.Layout.ProgressAnimation.X) * ratio;
            var ny = Meta.Layout.ProgressAnimation.Y + (Meta.Layout.ProgressAnimation.DY - Meta.Layout.ProgressAnimation.Y) * ratio;

            picProgressAnimation.SetBounds((int)nx, (int)ny, picProgressAnimation.Width, picProgressAnimation.Height);
        }

        private async void btnPatch_Click(object sender, EventArgs e)
        {
            // Startup
            Patching = true;
            prgProgress.Value = 0;
            prgProgress.SetState(ProgressBarStyle.Normal);
            txtStatus.Text = string.Empty;
            UpdateForm();

            // Variables
            var error = false;
            var percentage = 0;
            var variableCache = new Dictionary<string, object>();

            // Steps
            var patch = Patch.Load(Path.Combine(MetaDirectory, "patch.xml"));
            prgProgress.Maximum = patch.Steps.Sum(s => s.Weight);

            foreach (var step in patch.Steps)
            {
                if (!patch.Debug && step is IIsDebugStep) continue;

                if (step.Run != string.Empty)
                {
                    if (!variableCache.ContainsKey(step.Run))
                    {
                        prgProgress.Value = Math.Min(percentage + step.Weight, prgProgress.Maximum);
                        UpdateProgressAnimation();
                        continue;
                    }

                    if (bool.TryParse(variableCache[step.Run].ToString().ToLower(), out var run))
                        if (!run)
                        {
                            prgProgress.Value = Math.Min(percentage + step.Weight, prgProgress.Maximum);
                            UpdateProgressAnimation();
                            continue;
                        }
                }

                step.WorkingDirectory = Path.Combine(Environment.CurrentDirectory, BaseDirectory);

                var progress = new Progress<ProgressReport>(p =>
                {
                    prgProgress.Value = Math.Min(percentage + (int)(p.Percentage / 100 * step.Weight), prgProgress.Maximum);
                    UpdateProgressAnimation();
                    if (p.HasMessage)
                        txtStatus.AppendText(p.Message.Trim() + (p.NewLine ? "\r\n" : ""));
                });

                try
                {
                    var results = await step.Perform(variableCache, progress);

                    switch (results.Status)
                    {
                        case StepStatus.Failure:
                        case StepStatus.Cancel:
                        case StepStatus.Error:
                            error = true;
                            break;
                        case StepStatus.Success:
                        case StepStatus.Skip:
                            percentage += step.Weight;
                            break;
                    }

                    if (results.HasMessage)
                        txtStatus.AppendText(results.Message.Trim() + "\r\n");

                    switch (results.Status)
                    {
                        case StepStatus.Failure:
                        case StepStatus.Error:
                            txtStatus.AppendText("打补丁失败.");
                            break;
                        case StepStatus.Cancel:
                            txtStatus.AppendText("已取消打补丁操作.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    txtStatus.AppendText("例外: " + ex.Message.Trim());
                    error = true;
                }

                if (error)
                    break;
                if (Cancelled)
                    break;
            }

            if (error)
            {
                await Task.Delay(250);
                prgProgress.SetState(ProgressBarStyle.Error);
            }
            else if (Cancelled)
            {
                await Task.Delay(250);
                prgProgress.SetState(ProgressBarStyle.Pause);
            }

            if (!error && !Cancelled)
            {
                txtStatus.AppendText("已成功应用修补程序!");
                prgProgress.Value = prgProgress.Maximum;
            }
            if (Cancelled)
                txtStatus.AppendText("已取消...");

            Patching = false;
            Cancelled = false;
            UpdateForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Patching)
                Close();
            else
            {
                Patching = false;
                Cancelled = true;
                btnExit.Text = "正在取消...";
                btnExit.Enabled = false;
            }
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            MusicOn = !MusicOn;
            UpdateMusic();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Meta.About}", $"关于 {Meta.Title}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Meta.Website);
        }

        private void DoubleBuffer(Control ctrl, bool doubleBuffered)
        {
            ctrl.GetType().GetProperty("双重缓冲", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ctrl, doubleBuffered, null);
        }
    }
}
