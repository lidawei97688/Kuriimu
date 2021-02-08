using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kuriimu.Properties;

namespace Kuriimu
{
    public partial class Name : Form
    {
        private string _name = null;
        private bool _namesMustBeUnique = false;
        private IEnumerable<string> _nameList = null;
        private string _validNameRegex = ".*";
        private int _maxLength = 0;
        private bool _isNew = false;

        #region Properties

        public string Entry
        {
            set => _name = value;
        }

        public bool NamesMustBeUnique
        {
            set => _namesMustBeUnique = value;
        }

        public IEnumerable<string> NameList
        {
            set => _nameList = value;
        }

        public bool IsNew
        {
            set => _isNew = value;
        }

        public string NewName { get; private set; } = string.Empty;

        public bool NameChanged { get; private set; } = false;

        #endregion

        public Name(string name, bool namesMustBeUnique = false, IEnumerable<string> nameList = null, string validNameRegex = ".*", int maxLength = 0, bool isNew = false)
        {
            InitializeComponent();

            _name = name;
            _namesMustBeUnique = namesMustBeUnique;
            _nameList = nameList;
            _validNameRegex = validNameRegex;
            _maxLength = maxLength;
            _isNew = isNew;
        }

        private void Name_Load(object sender, EventArgs e)
        {
            Text = _isNew ? "添加条目" : "重命名条目";
            Icon = Resources.kuriimu;

            txtName.MaxLength = _maxLength == 0 ? int.MaxValue : _maxLength;
            txtName.Text = _name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string oldName = _name.Trim();
            string newName = txtName.Text.Trim();
            NameChanged = oldName != newName;

            if (txtName.Text.Trim().Length <= _maxLength || _maxLength == 0)
                if (Regex.IsMatch(newName, _validNameRegex))
                    if (_namesMustBeUnique)
                    {
                        if (_nameList != null)
                        {
                            if (!_nameList.Contains(newName) || (oldName == newName && !_isNew))
                            {
                                NewName = newName;
                                DialogResult = DialogResult.OK;
                            }
                            else
                                MessageBox.Show("条目名称必须唯一 " + newName + " 已经存在。", "必须是唯一的", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("条目名称必须唯一，但文件插件未提供名称列表。", "文件插件错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        NewName = newName;
                        DialogResult = DialogResult.OK;
                    }
                else
                    MessageBox.Show("输入的名称包含无效字符。有效名称必须满足此正则表达式： " + _validNameRegex, "名称无效", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("输入的名称太长。有效名称的长度不能超过 " + _maxLength + " 个字符。", "新名称过长", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}