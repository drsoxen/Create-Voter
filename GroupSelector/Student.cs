using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupSelector
{
    public enum Job
    {
        WildCard = 0,
        Programming = 1,
        Art = 2,
        Design = 3,
        NoJob = 4
    }

    /// <summary>
    /// Defines a student
    /// </summary>
    public struct Student
    {
        public string LastName;
        public string FirstName;
        public string EmailID;
        public Job FirstChoice;
        public Job SecondChoice;
        public Job ThirdChoice;
        public Job FinalAssignment;

        public Student(string lastName,
                       string firstName,
                       string userName,
                       Job primary,
                       Job seconday,
                       Job tertiary)
        {
            LastName = lastName;
            FirstName = firstName;
            EmailID = userName;
            FirstChoice = primary;
            SecondChoice = seconday;
            ThirdChoice = tertiary;
            FinalAssignment = Job.NoJob;
        }
    }
}
