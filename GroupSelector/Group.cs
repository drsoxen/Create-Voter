using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupSelector
{
    /// <summary>
    /// Defines a group of students
    /// </summary>
    public class Group
    {
        #region Data Members

        private int mGroupNumber;
        private int mGroupSize;
        private List<Student> mGroupMembers;

        #endregion

        #region Properties

        public int GroupNumber
        {
            get { return mGroupNumber; }
            set { mGroupNumber = value; }
        }

        public List<Student> GroupMembers
        {
            get { return mGroupMembers; }
            set { mGroupMembers = value; }
        }

        public int MaxGroupSize
        {
            get { return mGroupSize; }
            set { mGroupSize = value; }
        }

        #endregion

        #region Constructors

        public Group()
        {
            mGroupNumber = -1;
            mGroupMembers = new List<Student>();
            mGroupSize = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a student to the group
        /// </summary>
        /// <param name="student">the student to add</param>
        /// <returns>false if the student already exists in the group</returns>
        public bool AddStudent(Student student)
        {
            if (mGroupMembers != null)
            {
                if (mGroupMembers.Contains(student) == true)
                {
                    //TODO: Add a message box pointing out the error
                    return false;
                }
                else
                {
                    mGroupMembers.Add(student);
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
