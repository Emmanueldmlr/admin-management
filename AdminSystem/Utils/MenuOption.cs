using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace AdminSystem.Utils
{
    public static class MenuOptions
    {
        public static List<string> Options = new List<string>
        {
            "Hi, this is an Admin system made by Bakare Damilare E. for Object Oriented Programming using C#",
            "Use numbers to define the actions you want to perform",
            "Press 1 to Create a new Programme: ",
            "Press 2 to View All Programmes: ",
            "Press 3 to Create a Student: ",
            "Press 4 to View All Students: ",
            "Press 5 to Create a New Module: ",
            "Press 6 to View All Modules: ",
            "Press 7 to Add a Module to a Program: ",
            "Press 8 to View all Program Modules: ",
            "Press 9 to Create an Assessment: ",
            "Press 10 to View all Assessments: ",
            "Press 11 to Add an Assessment to a Module: ",
            "Press 12 to View all Module Assessment: ",
            "Press 13 to Upload Student Assessment Result",
            "Press 14 to View all Students Uploaded Grades",
            "Press 15 to Calculate Student Module Grade",
            "Press 16 to Calculate Student Program Grade"
        };
    }
}

