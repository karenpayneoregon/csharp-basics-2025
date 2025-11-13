# My Notes


## SQL Server 2022

### Get age w/o computed column

* The query selects several columns from the table **dbo.BirthDays**:
  **Id**, **FirstName**, **LastName**, and **BirthDate**.

* It calculates an **Age** value on the fly instead of storing it in the table.

* To calculate Age, it formats today’s date (`GETDATE()`) as **yyyyMMdd**, converts it to an integer, and does the same for the person’s **BirthDate**.

* It subtracts the birthdate integer from today’s integer.
  Example: `20250314 - 19880622 = 237292`.

* Dividing that difference by **10000** trims off the month/day noise and yields a rough age in years.

* The result isn’t perfect for edge-case birthdays (because it doesn’t check whether the birthday has occurred yet this year), but it’s a quick-and-dirty age calculation SQL developers commonly use.

* The final output includes all selected fields along with the computed **Age** column for each row in **dbo.BirthDays**.


```sql
SELECT Id,
    FirstName,
    LastName,
    BirthDate,
    (CAST(FORMAT(GETDATE(), 'yyyyMMdd') AS INTEGER) - CAST(FORMAT(BirthDate, 'yyyyMMdd') AS INTEGER)) / 10000 AS Age
FROM dbo.BirthDays;
```

### Get age with computed column

```sql
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
	[YearsOld]  AS (datediff(year,[BirthDate],getdate())),
	[FullName]  AS (([FirstName]+' ')+[LastName]),
	[BirthYear]  AS (datepart(year,[BirthDate])),
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Karen', N'Payne', CAST(N'1956-09-24' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Mike', N'Williams', CAST(N'1999-11-02' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Jane', N'Adams', CAST(N'1999-10-11' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Greg', N'Smith', CAST(N'1970-01-05' AS Date))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Anne', N'Harrison', CAST(N'1955-04-05' AS Date))
```

## C#

### Check if a value is between two other values

:small_orange_diamond: See [IComparable](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-9.0)

```csharp
public static class GenericExtensions
{
        /// <summary>
        /// Determine if T is between lower and upper
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="value">Value to determine if between lower and upper</param>
        /// <param name="lowerValue">Lower of range</param>
        /// <param name="upperValue">Upper of range</param>
        /// <returns>True if in range, false if not in range</returns>
        /// <example>
        /// <code>
        /// var startDate = new DateTime(2018, 12, 2, 1, 12, 0);
        /// var endDate = new DateTime(2018, 12, 15, 1, 12, 0);
        /// var theDate = new DateTime(2018, 12, 13, 1, 12, 0);
        /// Assert.IsTrue(theDate.Between(startDate,endDate));
        /// </code>
        /// </example>
        public static bool Between<T>(this T value, T lowerValue, T upperValue) where T : struct, IComparable<T> => 
            Comparer<T>.Default.Compare(value, lowerValue) >= 0 && Comparer<T>.Default.Compare(value, upperValue) <= 0;
}
```