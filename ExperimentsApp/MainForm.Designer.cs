namespace ExperimentsApp;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        RawSqlButton = new Button();
        SuspendLayout();
        // 
        // RawSqlButton
        // 
        RawSqlButton.Location = new Point(27, 39);
        RawSqlButton.Name = "RawSqlButton";
        RawSqlButton.Size = new Size(94, 29);
        RawSqlButton.TabIndex = 0;
        RawSqlButton.Text = "Raw SQL";
        RawSqlButton.UseVisualStyleBackColor = true;
        RawSqlButton.Click += RawSqlButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(431, 178);
        Controls.Add(RawSqlButton);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button RawSqlButton;
}
