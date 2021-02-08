using System;
using System.IO;
using System.Windows.Forms;
using Kontract.Encryption.AES.CTR;
using Kontract.Encryption;
using Kontract.IO;
using Kontract;

namespace Kontract.UI
{
    public static class EncryptionTools
    {
        public static void LoadEncryptionTools(ToolStripMenuItem tsb)
        {
            ToolStripMenuItem tsb2;
            ToolStripMenuItem tsb3;
            ToolStripMenuItem tsb4;
            tsb.DropDownItems.Clear();

            //General
            tsb.DropDownItems.Add(new ToolStripMenuItem("通用", null));
            tsb2 = (ToolStripMenuItem)tsb.DropDownItems[0];
            tsb2.DropDownItems.Add(new ToolStripMenuItem("Blowfish", null));
            tsb3 = (ToolStripMenuItem)tsb2.DropDownItems[0];
            tsb3.DropDownItems.Add(new ToolStripMenuItem("CBC", null));
            tsb4 = (ToolStripMenuItem)tsb3.DropDownItems[0];
            tsb4.DropDownItems.Add(new ToolStripMenuItem("加密", null, Encrypt));
            tsb4.DropDownItems[0].Tag = Types.BlowFishCBC;
            tsb4.DropDownItems.Add(new ToolStripMenuItem("解密", null, Decrypt));
            tsb4.DropDownItems[1].Tag = Types.BlowFishCBC;
            tsb3.DropDownItems.Add(new ToolStripMenuItem("EBC", null));
            tsb4 = (ToolStripMenuItem)tsb3.DropDownItems[1];
            tsb4.DropDownItems.Add(new ToolStripMenuItem("加密", null, Encrypt));
            tsb4.DropDownItems[0].Tag = Types.BlowFishECB;
            tsb4.DropDownItems.Add(new ToolStripMenuItem("解密", null, Decrypt));
            tsb4.DropDownItems[1].Tag = Types.BlowFishECB;

            // 3DS
            tsb.DropDownItems.Add(new ToolStripMenuItem("3DS", null));
            tsb2 = (ToolStripMenuItem)tsb.DropDownItems[1];
            tsb2.DropDownItems.Add(new ToolStripMenuItem("解密", null));
            tsb3 = (ToolStripMenuItem)tsb2.DropDownItems[0];
            tsb3.DropDownItems.Add(new ToolStripMenuItem(".3ds", null, Decrypt));
            tsb3.DropDownItems[0].Tag = Types.Normal;
            tsb3.DropDownItems.Add(new ToolStripMenuItem("CIA", null));
            tsb4 = (ToolStripMenuItem)tsb3.DropDownItems[1];
            tsb4.DropDownItems.Add(new ToolStripMenuItem("Shallow", null, Decrypt));
            tsb4.DropDownItems[0].Tag = Types.CIA_shallow;
            tsb4.DropDownItems.Add(new ToolStripMenuItem("Deep", null, Decrypt));
            tsb4.DropDownItems[1].Tag = Types.CIA_deep;
            tsb3.DropDownItems.Add(new ToolStripMenuItem("NCCH", null, Decrypt));
            tsb3.DropDownItems[2].Tag = Types.NCCH;
            /*tsb3.DropDownItems.Add(new ToolStripMenuItem("BOSS", null, Decrypt));
            tsb3.DropDownItems[2].Tag = Types.BOSS;*/

            //Mobile
            tsb.DropDownItems.Add(new ToolStripMenuItem("Mobile", null));
            tsb2 = (ToolStripMenuItem)tsb.DropDownItems[2];
            tsb2.DropDownItems.Add(new ToolStripMenuItem("MT Framework", null));
            tsb3 = (ToolStripMenuItem)tsb2.DropDownItems[0];
            tsb3.DropDownItems.Add(new ToolStripMenuItem("加密", null, Encrypt));
            tsb3.DropDownItems[0].Tag = Types.MTMobile;
            tsb3.DropDownItems.Add(new ToolStripMenuItem("解密", null, Decrypt));
            tsb3.DropDownItems[1].Tag = Types.MTMobile;

            //Switch
            tsb.DropDownItems.Add(new ToolStripMenuItem("Switch", null));
            tsb2 = (ToolStripMenuItem)tsb.DropDownItems[3];
            tsb2.DropDownItems.Add(new ToolStripMenuItem("解密", null));
            tsb3 = (ToolStripMenuItem)tsb2.DropDownItems[0];
            tsb3.DropDownItems.Add(new ToolStripMenuItem(".xci", null, Decrypt));
            tsb3.DropDownItems[0].Tag = Types.NSW_XCI;
            tsb3.DropDownItems.Add(new ToolStripMenuItem(".nca", null, Decrypt));
            tsb3.DropDownItems[1].Tag = Types.NSW_NCA;
        }

        public static void Decrypt(object sender, EventArgs e)
        {
            var tsi = sender as ToolStripMenuItem;
            var name = (tsi.Tag.ToString() == "normal") ? "3DS" : tsi.Tag.ToString();

            FileStream openFile;
            FileStream saveFile = null;
            if ((Types)tsi.Tag != Types.NSW_XCI && (Types)tsi.Tag != Types.NSW_NCA)
            {
                if (!Shared.PrepareFiles("打开一个加密的 " + name + " 文件...", "保存解密的文件到...", ".dec", out openFile, out saveFile))
                    return;
            }
            else
            {
                var ofd = new OpenFileDialog
                {
                    Title = "打开一个加密的 " + name + " 文件...",
                    Filter = "所有文件 (*.*)|*.*"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                    openFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.ReadWrite);
                else return;
            }

            bool show = true;

            try
            {
                using (var openBr = new BinaryReaderX(openFile))
                {
                    switch (tsi.Tag)
                    {
                        case Types.BlowFishCBC:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var key = InputBox.Show("输入解密密钥:", "解密 Blowfish");

                                if (key == String.Empty) throw new Exception("密钥不能为空！");
                                var bf = new BlowFish(key);
                                outFs.Write(bf.Decrypt_CBC(openBr.ReadAllBytes()));
                            }
                            break;
                        case Types.BlowFishECB:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var key = InputBox.Show("输入解密密钥:", "解密 Blowfish");

                                if (key == String.Empty) throw new Exception("密钥不能为空！");
                                var bf = new BlowFish(key);
                                outFs.Write(bf.Decrypt_ECB(openBr.ReadAllBytes()));
                            }
                            break;
                        case Types.MTMobile:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var key1 = InputBox.Show("输入第一个解密密钥:", "解密 MTMobile");
                                var key2 = InputBox.Show("输入第二个解密密钥:", "解密 MTMobile");

                                if (key1 == String.Empty || key2 == String.Empty) throw new Exception("密钥不能为空！");
                                outFs.Write(MTFramework.Decrypt(openBr.BaseStream, key1, key2));
                            }
                            break;
                        case Types.Normal:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var engine = new AesEngine();
                                openBr.BaseStream.CopyTo(outFs.BaseStream);
                                openBr.BaseStream.Position = 0;
                                outFs.BaseStream.Position = 0;
                                engine.DecryptGameNCSD(openBr.BaseStream, outFs.BaseStream);
                            }
                            break;
                        case Types.CIA_shallow:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var engine = new AesEngine();
                                openBr.BaseStream.CopyTo(outFs.BaseStream);
                                openBr.BaseStream.Position = 0;
                                outFs.BaseStream.Position = 0;
                                engine.DecryptCIA(openBr.BaseStream, outFs.BaseStream, true);
                            }
                            break;
                        case Types.CIA_deep:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var engine = new AesEngine();
                                openBr.BaseStream.CopyTo(outFs.BaseStream);
                                openBr.BaseStream.Position = 0;
                                outFs.BaseStream.Position = 0;
                                engine.DecryptCIA(openBr.BaseStream, outFs.BaseStream, false);
                            }
                            break;
                        case Types.NCCH:
                            using (var outFs = new BinaryWriterX(saveFile))
                            {
                                var engine = new AesEngine();
                                openBr.BaseStream.CopyTo(outFs.BaseStream);
                                openBr.BaseStream.Position = 0;
                                outFs.BaseStream.Position = 0;
                                engine.DecryptNCCH(openBr.BaseStream, outFs.BaseStream);
                            }
                            break;
                        /*case Types.BOSS:
                            outFs.Write(engine.DecryptBOSS(openBr.ReadBytes((int)openBr.BaseStream.Length)));
                            break;*/

                        case Types.NSW_XCI:
                            openBr.BaseStream.Position = 0;
                            
                            Switch.DecryptXCI(openBr.BaseStream);

                            MessageBox.Show("XCI Header 和所有 NCA 已成功解密！", "解密成功", MessageBoxButtons.OK);
                            show = false;
                            break;
                        case Types.NSW_NCA:
                            openBr.BaseStream.Position = 0;

                            Switch.DecryptNCA(openBr.BaseStream, 0);

                            MessageBox.Show("NCA 已成功解密！", "解密成功", MessageBoxButtons.OK);
                            show = false;
                            break;
                    }
                }

                if (show)
                    MessageBox.Show($"已成功解密 {Path.GetFileName(openFile.Name)}.", tsi?.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), tsi?.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(saveFile.Name);
            }
        }

        public static void Encrypt(object sender, EventArgs e)
        {
            var tsi = sender as ToolStripMenuItem;

            if (!Shared.PrepareFiles("打开一个解密的 " + tsi?.Tag + " 文件...", "保存加密的文件到...", ".dec", out var openFile, out var saveFile, true)) return;

            try
            {
                using (var openFs = new BinaryReaderX(openFile))
                using (var outFs = new BinaryWriterX(saveFile))
                    switch (tsi?.Tag)
                    {
                        case Types.BlowFishCBC:
                            var key = InputBox.Show("输入加密秘钥:", "加密 Blowfish");

                            if (key == String.Empty) throw new Exception("密钥不能为空！");
                            var bf = new BlowFish(key);
                            outFs.Write(bf.Encrypt_CBC(openFs.ReadAllBytes()));
                            break;
                        case Types.BlowFishECB:
                            key = InputBox.Show("输入加密秘钥:", "加密 Blowfish");

                            if (key == String.Empty) throw new Exception("密钥不能为空！");
                            bf = new BlowFish(key);
                            outFs.Write(bf.Encrypt_ECB(openFs.ReadAllBytes()));
                            break;
                        case Types.MTMobile:
                            var key1 = InputBox.Show("输入第一个加密秘钥:", "加密 MTMobile");
                            var key2 = InputBox.Show("输入第二个加密秘钥:", "加密 MTMobile");

                            if (key1 == String.Empty || key2 == String.Empty) throw new Exception("密钥不能为空！");
                            outFs.Write(MTFramework.Encrypt(openFs.BaseStream, key1, key2));
                            break;
                    }

                MessageBox.Show($"已成功加密 {Path.GetFileName(openFile.Name)}.", tsi.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), tsi?.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(saveFile.Name);
            }
        }

        public enum Types
        {
            //3DS
            Normal,
            CIA_shallow,
            CIA_deep,
            NCCH,
            BOSS,

            //Mobile
            BlowFishCBC,
            BlowFishECB,
            MTMobile,

            //Switch
            NSW_XCI,
            NSW_NCA
        }
    }
}
