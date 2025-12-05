#pragma warning disable CS0219 // Variable is assigned but its value is never used
using ExperimentsApp.Classes;
using ExperimentsApp.Classes.Configuration;
using ExperimentsApp.Classes.Presentation;

namespace ExperimentsApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        Shown += MainForm_Shown;
    }

    private void MainForm_Shown(object? sender, EventArgs e)
    {
        var connection = DataConnections.Instance.MainConnection;
    }

    private void RawSqlButton_Click(object sender, EventArgs e)
    {

        string statement =
            """
            SELECT Cust.CustomerIdentifier,
                Cust.CompanyName,
                Cust.ContactName,
                C.[Name] AS Country
            FROM dbo.Customers AS Cust
                 INNER JOIN dbo.Countries AS C 
            		ON Cust.CountryIdentifier = C.CountryIdentifier
            ORDER BY Cust.CompanyName
            OFFSET 100 ROWS 
            FETCH NEXT 10 ROWS ONLY;
            """;

    }

    private void HashingButton_Click(object sender, EventArgs e)
    {

        // Create the hash
        byte[] hash = HashUtility.HashString(HashOriginalTextBox.Text);
        string hashHex = Convert.ToHexString(hash);
        HashedTextBox.Text = hashHex;


        // Validate 
        bool matches = HashUtility.ValidateString(HashCheckTextBox.Text, hash);

        if (matches)
        {
            Dialogs.Information(this, $"Validation: {matches.ToYesNo()}");
        }
        else
        {
            Dialogs.Information(this, $"Validation: {matches.ToYesNo()}", "Sad");
        }


    }

    private void DivideByZeroButton_Click(object sender, EventArgs e)
    {
        ExceptionExamples.ExampleUsage(this);
    }

    private void AnonymousToTypeButton_Click(object sender, EventArgs e)
    {
        MemberOperations.GroupedMembers(MemberOperations.MembersList());
    }
}
