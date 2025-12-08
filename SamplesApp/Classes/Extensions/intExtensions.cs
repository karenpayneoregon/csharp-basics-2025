using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesApp.Classes.Extensions;
public static class Extensions
{
    public static (string grade, string remarks) GetGradeWithRemarks(this int score) => score switch
    {
        >= 90 => ("A", "Great job"),
        >= 80 and < 90 => ("B", "Good"),
        >= 70 and < 80 => ("C", "Okay"),
        >= 60 and < 70 => ("D", "Better study"),
        >= 50 and < 60 => ("F", "You failed"),
        _ => throw new ArgumentOutOfRangeException(
            nameof(score), score, "Unexpected value")
    };
}