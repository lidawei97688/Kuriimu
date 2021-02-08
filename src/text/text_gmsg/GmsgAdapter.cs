﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using text_gmsg.Properties;
using Kontract.Interface;
using Kontract;
using Kontract.IO;

namespace text_gmsg
{
    public sealed class GmsgAdapter : ITextAdapter
    {
        private FileInfo _fileInfo = null;
        private GMSG _gmsg = null;
        private GMSG _gmsgBackup = null;
        private List<Entry> _entries = null;

        #region Properties

        // Information
        public string Name => "GMSG";

        public string Description => "General Messages";

        public string Extension => "*.gmsg";

        public string About => "This is the GMSG text adapter for Kuriimu.";

        // Feature Support
        public bool FileHasExtendedProperties => false;

        public bool CanSave => true;

        public bool CanAddEntries => false;

        public bool CanRenameEntries => false;

        public bool CanDeleteEntries => false;

        public bool CanSortEntries => true;

        public bool EntriesHaveSubEntries => false;

        public bool EntriesHaveUniqueNames => true;

        public bool EntriesHaveExtendedProperties => false;

        public FileInfo FileInfo
        {
            get
            {
                return _fileInfo;
            }
            set
            {
                _fileInfo = value;
            }
        }

        public string LineEndings => "\n";

        #endregion

        public bool Identify(string filename)
        {
            using (BinaryReaderX br = new BinaryReaderX(File.OpenRead(filename)))
            {
                if (br.BaseStream.Length < 4) return false;
                return br.ReadString(4) == "GMSG";
            }
        }

        //Load file, make backup if needed
        public LoadResult Load(string filename, bool autoBackup = false)
        {
            LoadResult result = LoadResult.Success;

            _fileInfo = new FileInfo(filename);
            _entries = null;

            if (_fileInfo.Exists)
            {
                _gmsg = new GMSG(_fileInfo.FullName);

                string backupFilePath = _fileInfo.FullName + ".bak";
                if (File.Exists(backupFilePath))
                {
                    _gmsgBackup = new GMSG(backupFilePath);
                }
                else if (autoBackup || MessageBox.Show("在显示原始文本进行编辑之前，\r\n是否要创建 " + _fileInfo.Name + " 的备份？", "创建备份", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Copy(_fileInfo.FullName, backupFilePath);
                    _gmsgBackup = new GMSG(backupFilePath);
                }
                else
                {
                    _gmsgBackup = null;
                }
            }
            else
                result = LoadResult.FileNotFound;

            return result;
        }

        public SaveResult Save(string filename = "")
        {
            SaveResult result = SaveResult.Success;

            if (filename.Trim() != string.Empty)
                _fileInfo = new FileInfo(filename);

            try
            {
                _gmsg.Save(_fileInfo.FullName);
            }
            catch (Exception)
            {
                result = SaveResult.Failure;
            }

            return result;
        }

        // Entries
        public IEnumerable<TextEntry> Entries
        {
            get
            {
                if (_entries == null)
                {
                    _entries = new List<Entry>();

                    foreach (Label label in _gmsg.Labels)
                    {
                        if (_gmsgBackup == null)
                        {
                            Entry entry = new Entry(label);
                            _entries.Add(entry);
                        }
                        else
                        {
                            Entry entry = new Entry(label, _gmsgBackup.Labels.FirstOrDefault(o => o.TextID == label.TextID));
                            _entries.Add(entry);
                        }
                    }
                }

                if (SortEntries)
                    return _entries.OrderBy(e => e.Name).ThenBy(e => e.EditedLabel.TextID);

                return _entries;
            }
        }

        public IEnumerable<string> NameList => Entries?.Select(o => o.Name);

        public string NameFilter => @".*";

        public int NameMaxLength => 0;

        // Features
        public bool ShowProperties(Icon icon) => false;

        public TextEntry NewEntry() => new Entry();

        public bool AddEntry(TextEntry entry) => false;

        public bool RenameEntry(TextEntry entry, string newName) => false;

        public bool DeleteEntry(TextEntry entry) => false;

        public bool ShowEntryProperties(TextEntry entry, Icon icon) => false;

        // Settings
        public bool SortEntries
        {
            get { return Settings.Default.SortEntries; }
            set
            {
                Settings.Default.SortEntries = value;
                Settings.Default.Save();
            }
        }
    }
}
