#region Copyright (c) 2003 Chris Sells
/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion

namespace FormatDesigner
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Security;
    using System.Windows.Forms;

    partial class FormatDesignerForm : Form
    {

        public FormatDesignerForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new FormatDesignerForm());
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // Don't let it resize to be higher or shorter
            // Don't let it resize to be thinner
            // Do let it resize to be fatter
            // NOTE: doing it this way to take font scaling into account
            MinimumSize = Size;
            MaximumSize = new Size(int.MaxValue, Size.Height);

            // Select first type
            typeList.SelectedIndex = 0;

            // Fill culture list and select current culture entry
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                cultureList.Items.Add(new CultureListItem(culture));

            cultureList.SelectedItem = new CultureListItem(CultureInfo.CurrentCulture);
        }

        object CreateObjectAndParseString(string typeName, string parseArg)
        {
            // Shortcut string parsing
            var type = Type.GetType(typeName);
            if (type == typeof(String)) return parseArg;

            // Ask type to create a new instance using the static Parse method
            var method = type.GetMethod("Parse", new Type[] { typeof(String) });
            return method.Invoke(null, new object[] { parseArg });
        }

        void UpdateOutput()
        {
            // Create instance of type using input value
            var typeName = typeList.SelectedItem.ToString();
            var input = inputText.Text;
            var culture = cultureList.SelectedItem == null ? null : ((CultureListItem)cultureList.SelectedItem).Info;

            try
            {
                var obj = CreateObjectAndParseString(typeName, input);

                // Format object using format string
                var format = formatText.Text;

                outputText.Text = string.Format(culture, "{0:" + format + "}", obj);
                outputText.ForeColor = SystemColors.WindowText;

                // Show string.Format and ToString sytax
                if (format.Length > 0)
                {
                    stringFormatText.Text = string.Format("String.Format(\"{{0:{0}}}\")", format);
                    toStringText.Text = string.Format("ToString(\"{0}\")", format);
                }
                else
                {
                    stringFormatText.Text = "String.Format(\"{0}\")";
                    toStringText.Text = "ToString()";
                }
            }
            catch (Exception e)
            {
                outputText.Text = e.Message;
                outputText.ForeColor = Color.Red;
                stringFormatText.Text = "";
                toStringText.Text = "";
            }
        }

        void InputChanged(object sender, EventArgs e)
        {
            UpdateOutput();
        }

        void ShowHelp()
        {
            Process.Start("http://www.oreilly.com/catalog/csharpnut/chapter/appb.pdf");
        }

        void helpButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowHelp();
            }
            catch (SecurityException)
            {
                (new CantShowHelpForm()).ShowDialog(this);
            }
        }

        void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "FormatDesigner is an application to experiment with\r\n" +
              "the format strings used to format data in String.Format\r\n" +
              "and various type's ToString functions.\r\nEnjoy.\r\n" +
              "Copyright (c) 2003, Chris Sells", "FormatDesigner");
        }

        void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        [Serializable]
        sealed class CultureListItem
        {
            public readonly CultureInfo Info;

            public CultureListItem(CultureInfo info)
            {
                Info = info.IsReadOnly ? info : CultureInfo.ReadOnly(info);
            }

            public override bool Equals(object obj)
            {
                var item = obj as CultureListItem;
                if (item == null)
                    return false;
                return Info.Equals(item.Info);
            }

            public override int GetHashCode()
            {
                return Info.GetHashCode();
            }

            public override string ToString()
            {
                return Info.DisplayName;
            }
        }
    }
}
