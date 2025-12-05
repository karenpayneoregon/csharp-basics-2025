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
        HashingButton = new Button();
        HashOriginalTextBox = new TextBox();
        HashCheckTextBox = new TextBox();
        label1 = new Label();
        label2 = new Label();
        groupBox1 = new GroupBox();
        HashedTextBox = new TextBox();
        DivideByZeroButton = new Button();
        AnonymousToTypeButton = new Button();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // RawSqlButton
        // 
        RawSqlButton.Location = new Point(27, 12);
        RawSqlButton.Name = "RawSqlButton";
        RawSqlButton.Size = new Size(179, 29);
        RawSqlButton.TabIndex = 0;
        RawSqlButton.Text = "Raw SQL";
        RawSqlButton.UseVisualStyleBackColor = true;
        RawSqlButton.Click += RawSqlButton_Click;
        // 
        // HashingButton
        // 
        HashingButton.Location = new Point(8, 43);
        HashingButton.Name = "HashingButton";
        HashingButton.Size = new Size(94, 29);
        HashingButton.TabIndex = 1;
        HashingButton.Text = "Hashing";
        HashingButton.UseVisualStyleBackColor = true;
        HashingButton.Click += HashingButton_Click;
        // 
        // HashOriginalTextBox
        // 
        HashOriginalTextBox.Location = new Point(116, 45);
        HashOriginalTextBox.Name = "HashOriginalTextBox";
        HashOriginalTextBox.Size = new Size(172, 27);
        HashOriginalTextBox.TabIndex = 2;
        HashOriginalTextBox.Text = "MySecretPassword";
        // 
        // HashCheckTextBox
        // 
        HashCheckTextBox.Location = new Point(318, 45);
        HashCheckTextBox.Name = "HashCheckTextBox";
        HashCheckTextBox.Size = new Size(172, 27);
        HashCheckTextBox.TabIndex = 3;
        HashCheckTextBox.Text = "MySecretPassword";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(116, 26);
        label1.Name = "label1";
        label1.Size = new Size(114, 20);
        label1.TabIndex = 4;
        label1.Text = "Original to hash";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(318, 24);
        label2.Name = "label2";
        label2.Size = new Size(155, 20);
        label2.TabIndex = 5;
        label2.Text = "Check against original";
        // 
        // groupBox1
        // 
        groupBox1.BackColor = Color.Cornsilk;
        groupBox1.Controls.Add(HashedTextBox);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(HashCheckTextBox);
        groupBox1.Controls.Add(HashOriginalTextBox);
        groupBox1.Controls.Add(HashingButton);
        groupBox1.Location = new Point(19, 191);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(594, 135);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        // 
        // HashedTextBox
        // 
        HashedTextBox.Location = new Point(8, 90);
        HashedTextBox.Name = "HashedTextBox";
        HashedTextBox.Size = new Size(580, 27);
        HashedTextBox.TabIndex = 6;
        // 
        // DivideByZeroButton
        // 
        DivideByZeroButton.Location = new Point(27, 54);
        DivideByZeroButton.Name = "DivideByZeroButton";
        DivideByZeroButton.Size = new Size(179, 29);
        DivideByZeroButton.TabIndex = 7;
        DivideByZeroButton.Text = "DivideByZero";
        DivideByZeroButton.UseVisualStyleBackColor = true;
        DivideByZeroButton.Click += DivideByZeroButton_Click;
        // 
        // AnonymousToTypeButton
        // 
        AnonymousToTypeButton.Location = new Point(37, 101);
        AnonymousToTypeButton.Name = "AnonymousToTypeButton";
        AnonymousToTypeButton.Size = new Size(169, 29);
        AnonymousToTypeButton.TabIndex = 8;
        AnonymousToTypeButton.Text = "Anonymous to Type";
        AnonymousToTypeButton.UseVisualStyleBackColor = true;
        AnonymousToTypeButton.Click += AnonymousToTypeButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(625, 388);
        Controls.Add(AnonymousToTypeButton);
        Controls.Add(DivideByZeroButton);
        Controls.Add(groupBox1);
        Controls.Add(RawSqlButton);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Examples";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button RawSqlButton;
    private Button HashingButton;
    private TextBox HashOriginalTextBox;
    private TextBox HashCheckTextBox;
    private Label label1;
    private Label label2;
    private GroupBox groupBox1;
    private TextBox HashedTextBox;
    private Button DivideByZeroButton;
    private Button AnonymousToTypeButton;
}
