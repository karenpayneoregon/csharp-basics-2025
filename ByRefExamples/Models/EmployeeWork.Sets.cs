namespace ByRefExamples.Models;
/// <summary>
/// Represents an employee's work-related data and operations, including 
/// properties for tracking hours worked, hourly wage, overtime details, 
/// and salary. This class provides functionality to manage and update 
/// these properties while ensuring proper notifications for changes.
/// </summary>
/// <remarks>
/// This class is a partial class, allowing its definition to be split 
/// across multiple files. It is designed to work with property setters 
/// that support change notifications, leveraging the functionality 
/// provided by the <see cref="PropertySetters"/> base class.
/// </remarks>
public partial class EmployeeWork
{
    public partial int Id { get; set => SetField(ref field, value); }

    public partial decimal HourlyWage
    {
        get; 
        set => SetField(ref field, value);
    }

    public partial int HoursWorked
    {
        get;
        set => SetField(ref field, value);
    }

    public partial decimal OvertimeRate
    {
        get;
        set => SetField(ref field, value);
    }

    public partial int OvertimeThreshold
    {
        get;
        set => SetField(ref field, value);
    }

    public partial decimal Salary
    {
        get;
        private set => SetField(ref field, value);
    }


    public partial void PerformWork()
    {
        // TODO
    }
}
