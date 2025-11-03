
#pragma warning disable CS0219 // Variable is assigned but its value is never used
namespace ExperimentsApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
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
}
