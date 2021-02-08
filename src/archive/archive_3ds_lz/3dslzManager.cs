﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Kontract.Interface;
using Kontract.IO;

namespace archive_3ds_lz
{
    public class _3dslzManager : IArchiveManager
    {
        private _3DSLZ _3dslz = null;

        #region Properties

        // Information
        public string Name => Properties.Settings.Default.PluginName;
        public string Description => "3DZ_LZ Archive";
        public string Extension => "*.bin";
        public string About => "This is the 3DZ_LZ archive manager for Karameru.";

        // Feature Support
        public bool FileHasExtendedProperties => false;
        public bool CanAddFiles => false;
        public bool CanRenameFiles => false;
        public bool CanReplaceFiles => true;
        public bool CanDeleteFiles => false;
        public bool CanSave => true;

        public FileInfo FileInfo { get; set; }

        #endregion

        public bool Identify(string filename)
        {
            using (var br = new BinaryReaderX(File.OpenRead(filename)))
            {
                if (br.BaseStream.Length < 8) return false;
                return br.ReadString(8) == "3DS-LZ\r\n";
            }
        }

        public void Load(string filename)
        {
            FileInfo = new FileInfo(filename);

            if (FileInfo.Exists)
                _3dslz = new _3DSLZ(FileInfo.OpenRead());
        }

        public void Save(string filename = "")
        {
            if (!string.IsNullOrEmpty(filename))
                FileInfo = new FileInfo(filename);

            if (MessageBox.Show("使用固定偏移量保存该文件？", "固定偏移量？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                _3dslz.UseFixedOffsets = true;

            // Save As...
            if (!string.IsNullOrEmpty(filename))
            {
                _3dslz.Save(FileInfo.Create());
                _3dslz.Close();
            }
            else
            {
                // Create the temp file
                _3dslz.Save(File.Create(FileInfo.FullName + ".tmp"));
                _3dslz.Close();
                // Delete the original
                FileInfo.Delete();
                // Rename the temporary file
                File.Move(FileInfo.FullName + ".tmp", FileInfo.FullName);
            }

            // Reload the new file to make sure everything is in order
            Load(FileInfo.FullName);
        }

        public void Unload()
        {
            _3dslz?.Close();
        }

        // Files
        public IEnumerable<ArchiveFileInfo> Files => _3dslz.Files;

        public bool AddFile(ArchiveFileInfo afi) => false;

        public bool DeleteFile(ArchiveFileInfo afi) => false;

        // Features
        public bool ShowProperties(Icon icon) => false;
    }
}
