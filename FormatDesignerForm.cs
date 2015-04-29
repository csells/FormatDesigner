// FormatDesignerForm.cs
#region Copyright
/*
Copyright © 2003 Chris Sells
This software is provided 'as-is', without any express or implied warranty.
In no event will the authors be held liable for any damages arising from
the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not claim
that you wrote the original software. If you use this software in a product,
an acknowledgment in the product documentation is requested, as shown here:

Portions copyright © 2002-2003 Chris Sells (http://www.sellsbrothers.com/).

2. No substantial portion of this source code may be redistributed without
the express written permission of the copyright holders, where "substantial"
is defined as enough code to be recognizably from this code. 
*/
#endregion
#region History
// -8/12/03:
//  -Atif Aziz sent along code to change the culture interactively. Thanks, Atif!
//  -Sorted Type field
//  -Made main window a tad wider
// -8/6/03: initial release
#endregion

using System;
using System.Reflection;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace FormatDesigner {
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class FormatDesignerForm : System.Windows.Forms.Form {
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox stringFormatText;
    private System.Windows.Forms.TextBox toStringText;
    private System.Windows.Forms.ComboBox typeList;
    private System.Windows.Forms.TextBox inputText;
    private System.Windows.Forms.TextBox formatText;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox outputText;
    private System.Windows.Forms.Button aboutButton;
    private System.Windows.Forms.Button helpButton;
    private System.Windows.Forms.Button exitButton;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.ComboBox cultureList;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public FormatDesignerForm() {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing ) {
      if( disposing ) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.stringFormatText = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.toStringText = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.typeList = new System.Windows.Forms.ComboBox();
      this.inputText = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.formatText = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.outputText = new System.Windows.Forms.TextBox();
      this.aboutButton = new System.Windows.Forms.Button();
      this.helpButton = new System.Windows.Forms.Button();
      this.exitButton = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.cultureList = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.stringFormatText);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.toStringText);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Location = new System.Drawing.Point(18, 184);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(332, 88);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Code Arguments";
      // 
      // stringFormatText
      // 
      this.stringFormatText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.stringFormatText.Location = new System.Drawing.Point(96, 24);
      this.stringFormatText.Name = "stringFormatText";
      this.stringFormatText.ReadOnly = true;
      this.stringFormatText.Size = new System.Drawing.Size(220, 20);
      this.stringFormatText.TabIndex = 1;
      this.stringFormatText.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(16, 21);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(80, 23);
      this.label5.TabIndex = 0;
      this.label5.Text = "String.Format";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toStringText
      // 
      this.toStringText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.toStringText.Location = new System.Drawing.Point(96, 56);
      this.toStringText.Name = "toStringText";
      this.toStringText.ReadOnly = true;
      this.toStringText.Size = new System.Drawing.Size(220, 20);
      this.toStringText.TabIndex = 3;
      this.toStringText.Text = "";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(16, 53);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(80, 23);
      this.label6.TabIndex = 2;
      this.label6.Text = "ToString";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(10, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Input";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(10, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(40, 23);
      this.label2.TabIndex = 2;
      this.label2.Text = "Type";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // typeList
      // 
      this.typeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.typeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.typeList.Items.AddRange(new object[] {
                                                  "System.DateTime",
                                                  "System.Decimal",
                                                  "System.Double",
                                                  "System.Int16",
                                                  "System.Int32",
                                                  "System.Int64",
                                                  "System.Single",
                                                  "System.String"});
      this.typeList.Location = new System.Drawing.Point(66, 55);
      this.typeList.Name = "typeList";
      this.typeList.Size = new System.Drawing.Size(284, 21);
      this.typeList.Sorted = true;
      this.typeList.TabIndex = 3;
      this.typeList.SelectedIndexChanged += new System.EventHandler(this.InputChanged);
      // 
      // inputText
      // 
      this.inputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.inputText.Location = new System.Drawing.Point(66, 23);
      this.inputText.Name = "inputText";
      this.inputText.Size = new System.Drawing.Size(282, 20);
      this.inputText.TabIndex = 1;
      this.inputText.Text = "1994-5-5";
      this.inputText.TextChanged += new System.EventHandler(this.InputChanged);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(10, 84);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 23);
      this.label3.TabIndex = 4;
      this.label3.Text = "Format";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // formatText
      // 
      this.formatText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.formatText.Location = new System.Drawing.Point(66, 87);
      this.formatText.Name = "formatText";
      this.formatText.Size = new System.Drawing.Size(282, 20);
      this.formatText.TabIndex = 5;
      this.formatText.Text = "MM dddd yy";
      this.formatText.TextChanged += new System.EventHandler(this.InputChanged);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(10, 151);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 23);
      this.label4.TabIndex = 8;
      this.label4.Text = "Output";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // outputText
      // 
      this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.outputText.Location = new System.Drawing.Point(66, 151);
      this.outputText.Name = "outputText";
      this.outputText.ReadOnly = true;
      this.outputText.Size = new System.Drawing.Size(284, 20);
      this.outputText.TabIndex = 9;
      this.outputText.Text = "";
      // 
      // aboutButton
      // 
      this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.aboutButton.Location = new System.Drawing.Point(276, 288);
      this.aboutButton.Name = "aboutButton";
      this.aboutButton.TabIndex = 13;
      this.aboutButton.Text = "&About";
      this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
      // 
      // helpButton
      // 
      this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.helpButton.Location = new System.Drawing.Point(188, 288);
      this.helpButton.Name = "helpButton";
      this.helpButton.TabIndex = 12;
      this.helpButton.Text = "&Help";
      this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
      // 
      // exitButton
      // 
      this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.exitButton.Location = new System.Drawing.Point(100, 288);
      this.exitButton.Name = "exitButton";
      this.exitButton.TabIndex = 11;
      this.exitButton.Text = "E&xit";
      this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(10, 116);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(46, 23);
      this.label7.TabIndex = 6;
      this.label7.Text = "Culture";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cultureList
      // 
      this.cultureList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.cultureList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cultureList.Location = new System.Drawing.Point(66, 119);
      this.cultureList.Name = "cultureList";
      this.cultureList.Size = new System.Drawing.Size(284, 21);
      this.cultureList.Sorted = true;
      this.cultureList.TabIndex = 7;
      this.cultureList.SelectedIndexChanged += new System.EventHandler(this.InputChanged);
      // 
      // FormatDesignerForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.exitButton;
      this.ClientSize = new System.Drawing.Size(360, 326);
      this.Controls.Add(this.aboutButton);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.typeList);
      this.Controls.Add(this.inputText);
      this.Controls.Add(this.formatText);
      this.Controls.Add(this.outputText);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.helpButton);
      this.Controls.Add(this.exitButton);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.cultureList);
      this.Name = "FormatDesignerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormatDesigner";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    // </summary>
    [STAThread]
    static void Main() {
      Application.Run(new FormatDesignerForm());
    }

    private void Form1_Load(object sender, System.EventArgs e) {
      // Don't let it resize to be higher or shorter
      // Don't let it resize to be thinner
      // Do let it resize to be fatter
      // NOTE: doing it this way to take font scaling into account
      this.MinimumSize = this.Size;
      this.MaximumSize = new Size(int.MaxValue, this.Size.Height);

      // Select first type
      this.typeList.SelectedIndex = 0;

      // Fill culture list and select current culture entry
      foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        this.cultureList.Items.Add(new CultureListItem(culture));

      this.cultureList.SelectedItem = new CultureListItem(CultureInfo.CurrentCulture);
    }

    object CreateObjectAndParseString(string typeName, string parseArg) {
      // Shortcut string parsing
      Type type = Type.GetType(typeName);
      if( type == typeof(System.String) ) return parseArg;

      // Ask type to create a new instance using the static Parse method
      MethodInfo method = type.GetMethod("Parse", new Type[] { typeof(System.String) });
      return method.Invoke(null, new object[] { parseArg });
    }

    void UpdateOutput() {
      // Create instance of type using input value
      string typeName = typeList.SelectedItem.ToString();
      string input = inputText.Text;
      CultureInfo culture = cultureList.SelectedItem == null ? null : ((CultureListItem) cultureList.SelectedItem).Info;

      try {
        object obj = CreateObjectAndParseString(typeName, input);

        // Format object using format string
        string format = formatText.Text;

        outputText.Text = string.Format(culture, "{0:" + format + "}", obj);
        outputText.ForeColor = SystemColors.WindowText;

        // Show string.Format and ToString sytax
        if( format.Length > 0 ) {
          stringFormatText.Text = string.Format("String.Format(\"{{0:{0}}}\")", format);
          toStringText.Text = string.Format("ToString(\"{0}\")", format);
        }
        else {
          stringFormatText.Text = "String.Format(\"{0}\")";
          toStringText.Text = "ToString()";
        }
      }
      catch( Exception e ) {
        outputText.Text = e.Message;
        outputText.ForeColor = Color.Red;
        stringFormatText.Text = "";
        toStringText.Text = "";
      }
    }

    private void InputChanged(object sender, System.EventArgs e) {
      UpdateOutput();
    }

    void ShowHelp() {
      System.Diagnostics.Process.Start("http://www.oreilly.com/catalog/csharpnut/chapter/appb.pdf");
    }

    private void helpButton_Click(object sender, System.EventArgs e) {
      try {
        ShowHelp();
      }
      catch( System.Security.SecurityException ) {
        (new CantShowHelpForm()).ShowDialog(this);
      }
    }

    private void aboutButton_Click(object sender, System.EventArgs e) {
      MessageBox.Show(
        "FormatDesigner is an application to experiment with\r\n" +
        "the format strings used to format data in String.Format\r\n" +
        "and various type's ToString functions.\r\nEnjoy.\r\n" +
        "Copyright (c) 2003, Chris Sells", "FormatDesigner");
    }

    private void exitButton_Click(object sender, System.EventArgs e) {
      this.Close();
    }

    [ Serializable ]
    private sealed class CultureListItem {
        public readonly CultureInfo Info;

        public CultureListItem(CultureInfo info) {
          this.Info = info.IsReadOnly ? info : CultureInfo.ReadOnly(info);
        }

        public override bool Equals(object obj) {
          CultureListItem item = obj as CultureListItem;
          if (item == null)
              return false;
          return this.Info.Equals(item.Info);
        }

        public override int GetHashCode() {
            return Info.GetHashCode();
        }

        public override string ToString() 
        {
          return Info.DisplayName;
        }
    }
  }
}
