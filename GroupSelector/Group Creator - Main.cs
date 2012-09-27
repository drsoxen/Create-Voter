/*
 *CREATE Club
 *Capstone Project Group Selector, Version 1.0
 *January 18, 2012
 *
 *Richard Von Dadelszen, David Barton, Christopher Ziraldo
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CreateServer;
using System.IO;

namespace GroupSelector
{
    public enum GroupFillResult
    {
        Empty = 0,
        NotEmpty = 1
    }

    public partial class MainForm : Form
    {
        const int NUMBER_PROGRAMMERS = 2;
        const int NUMBER_ARTISTS = 2;
        const int NUMBER_DESIGNERS = 1;

        const string WILD_CARD = "Wild Card";
        const string PROGRAMMER = "Programmer";
        const string ARTIST = "Artist";
        const string DESIGNER = "Designer";

        #region Data Members

        Dictionary<string, Student> mClassList;
        Dictionary<int, Group> mGroupList;
        List<Student> mListWildCard;
        List<Student> mListProgrammers;
        List<Student> mListArtists;
        List<Student> mListDesigners;
        int mNumberOfStudents;
        int mNumberOfGroups;
        int mExtraStudents;
        int mGroupSize;
        bool mGroupSizeSet;
        Server mVoteServer;
        Random mMrRandom;

        static List<string> mStaticStrings = new List<string>();

        public delegate void FillGroupDelegate(List<Student> students);
        FillGroupDelegate mDelegateFillGroup = null;

        #endregion

        #region Properties

        public int NumberOfStudents
        {
            get { return mNumberOfStudents; }
        }

        public int NumberOfGroups
        {
            get { return mNumberOfGroups; }
        }

        public int ExtraStudents
        {
            get { return mExtraStudents; }
        }

        public int GroupSize
        {
            get { return mGroupSize; }
        }

        #endregion

        #region Constructors

        public MainForm()
        {
            mClassList = new Dictionary<string, Student>();
            mGroupList = new Dictionary<int, Group>();
            mListWildCard = new List<Student>();
            mListProgrammers = new List<Student>();
            mListArtists = new List<Student>();
            mListDesigners = new List<Student>();
            mNumberOfStudents = 0;
            mNumberOfGroups = 0;
            mExtraStudents = 0;
            mGroupSize = 0;
            mGroupSizeSet = false;
            mVoteServer = new Server();
            mMrRandom = new Random();

            mDelegateFillGroup = FillSecondary;

            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a student to the class list 
        /// </summary>
        /// <param name="student">the student to add</param>
        /// <returns>returns false if the student already exists in the class list</returns>
        public bool AddStudent(Student student)
        {
            if (mClassList != null)
            {
                if (mClassList.ContainsKey(student.EmailID) == true)
                {
                    MessageBox.Show("Student already added to the class list", "Information");
                    return false;
                }
                else
                {
                    mClassList.Add(student.EmailID, student);
                    mNumberOfStudents++;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds the number of groups based on the class list
        /// </summary>
        public void CalculateNumberOfGroups()
        {
            for (int i = 0; i < mStaticStrings.Count; i++)
            {
                Student NewStudent = CreateStudentFromString(mStaticStrings[i]);
                AddStudent(NewStudent);
            }

            mNumberOfStudents = mClassList.Count;
            mGroupSize = (int)MainForm_GroupSizeCounter.Value;

            mNumberOfGroups = mNumberOfStudents / GroupSize;

            if (mNumberOfStudents > GroupSize)
            {
                mExtraStudents = mNumberOfStudents % GroupSize;
            }
            else
            {
                mExtraStudents = 0;
            }

            for (int i = 0; i < mNumberOfGroups; i++)
            {
                Group group = new Group();
                group.GroupNumber = i;
                group.MaxGroupSize = mGroupSize;
                mGroupList.Add(group.GroupNumber, group);
            }

            if (mExtraStudents > 0)
            {
                int Extras = mExtraStudents;
                int k = 0;
                while (Extras > 0)
                {
                    mGroupList[k].MaxGroupSize++;
                    k++;
                    Extras--;
                }
            }
        }

        /// <summary>
        /// Creates random groups based on skill pools
        /// </summary>
        public void CreateGroups()
        {
            Dictionary<string, Student> CopyClassList = new Dictionary<string, Student>();
            CopyClassList = mClassList;

            // adds the students to the lists based on preference 
            foreach (Student i in mClassList.Values)
            {
                if (i.FirstChoice == Job.WildCard)
                {
                    mListWildCard.Add(i);
                }
                else if (i.FirstChoice == Job.Programming)
                {
                    mListProgrammers.Add(i);
                }
                else if (i.FirstChoice == Job.Art)
                {
                    mListArtists.Add(i);
                }
                else if (i.FirstChoice == Job.Design)
                {
                    mListDesigners.Add(i);
                }
            }

            #region Fill The Groups

            int JobCounter = 3;

            // used to point at the necessary fill function
            mDelegateFillGroup = FillSecondary;

            // fill groups based on primary choice, then fill secondary, then tertiary
            for (int i = 0; i < JobCounter; i++)
            {             
                if (FillGroups(mListProgrammers, NUMBER_PROGRAMMERS) == GroupFillResult.NotEmpty)
                {
                    mDelegateFillGroup(mListProgrammers);
                }

                if (FillGroups(mListArtists, NUMBER_ARTISTS) == GroupFillResult.NotEmpty)
                {
                    mDelegateFillGroup(mListArtists);
                }

                if (FillGroups(mListDesigners, NUMBER_DESIGNERS) == GroupFillResult.NotEmpty)
                {
                    mDelegateFillGroup(mListDesigners);
                }

                switch (i)
                {
                    case 0:
                        mDelegateFillGroup = FillTertiary;
                        break;

                    case 1:
                        mDelegateFillGroup = FillWildCard;
                        break;
                }
            }

            // distribute wildcards
            if (mListWildCard.Count > 0)
            {
                FillGroups(mListWildCard, mListWildCard.Count);
            }

            #endregion

        }

        /// <summary>
        /// Check if the group has enough people to fill it
        /// </summary>
        /// <param name="idealNumber">number of individuals wanted to fill a particular discipline</param>
        /// <param name="studentJobList">the list of individuals sloted into a discipline</param>
        /// <returns>true if there are enough people to fill the discipline</returns>
        public bool CheckFillList(List<Student> studentJobList, int idealNumber)
        {
            int TotalNeeded = idealNumber * mNumberOfGroups;

            if (studentJobList.Count >= TotalNeeded)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fills the groups based on a discipline
        /// </summary>
        /// <param name="studentJobList">the list of individuals in a discipline</param>
        /// <param name="idealNumber">the number of individuals of a discipline that should ideally be placed in the group</param>
        /// <returns>whether the group has left over individuals because the ideal number of roles has been filled</returns>
        public GroupFillResult FillGroups(List<Student> studentJobList, int idealNumber)
        {
            int i = 0;
            while (i != idealNumber)
            {
                foreach (Group group in mGroupList.Values)
                {
                    // if there is nobody to fill the role, return
                    if (studentJobList.Count == 0)
                    {
                        return GroupFillResult.Empty;
                    }

                    if (group.GroupMembers.Count < group.MaxGroupSize)
                    {
                        group.AddStudent(studentJobList[0]);
                        studentJobList.RemoveAt(0);
                    }
                }

                i++;
            }

            if (studentJobList.Count > 0)
            {
                return GroupFillResult.NotEmpty;
            }
            else
            {
                return GroupFillResult.Empty;
            }
        }

        /// <summary>
        /// Fills the discipline lists based on secondary preference
        /// </summary>
        /// <param name="studentJobList">the list of individuals to be redistributed</param>
        public void FillSecondary(List<Student> studentJobList)
        {
            List<Student> tempList = studentJobList.ToList<Student>();

            foreach (Student student in tempList)
            {
                switch (student.SecondChoice)
                {
                    case Job.Programming:
                        {
                            if (!mListProgrammers.Contains(student))
                            {
                                mListProgrammers.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.Art:
                        {
                            if (!mListArtists.Contains(student))
                            {
                                mListArtists.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.Design:
                        {
                            if (!mListDesigners.Contains(student))
                            {
                                mListDesigners.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.WildCard:
                        {
                            if (!mListWildCard.Contains(student))
                            {
                                mListWildCard.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }

                }


            }

            //studentJobList.Clear();

        }

        /// <summary>
        /// Fills the discipline lists based on tertiary preference
        /// </summary>
        /// <param name="studentJobList">the list of individuals to be redistributed</param>
        public void FillTertiary(List<Student> studentJobList)
        {
            List<Student> tempList = studentJobList.ToList<Student>();

            foreach (Student student in tempList)
            {
                switch (student.ThirdChoice)
                {
                    case Job.Programming:
                        {
                            if (!mListProgrammers.Contains(student))
                            {
                                mListProgrammers.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.Art:
                        {
                            if (!mListArtists.Contains(student))
                            {
                                mListArtists.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.Design:
                        {
                            if (!mListDesigners.Contains(student))
                            {
                                mListDesigners.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                    case Job.WildCard:
                        {
                            if (!mListWildCard.Contains(student))
                            {
                                mListWildCard.Add(student);
                                studentJobList.Remove(student);
                            }
                            break;
                        }
                }

                //studentJobList.Clear();
            }
        }

        /// <summary>
        /// Fills the discipline lists based on wildcard preference
        /// </summary>
        /// <param name="studentJobList">the list of individuals to be redistributed</param>
        public void FillWildCard(List<Student> studentJobList)
        {
            foreach (Student student in studentJobList)
            {
                if (!mListWildCard.Contains(student))
                {
                    mListWildCard.Add(student);
                }
            }

            //studentJobList.Clear();

        }

        /// <summary>
        /// Parses a string that is used to initialize a new Student object 
        /// </summary>
        /// <param name="message">the message to be split and used to instantialize a new student</param>
        /// <returns>the student created from the message</returns>
        public Student CreateStudentFromString(string message)
        {
            string FirstName = message.Substring(0, message.IndexOf("/"));
            message = message.Remove(0, message.IndexOf("/") + 1);

            string LastName = message.Substring(0, message.IndexOf("/"));
            message = message.Remove(0, message.IndexOf("/") + 1);

            string UserName = message.Substring(0, message.IndexOf("/"));
            message = message.Remove(0, message.IndexOf("/") + 1);

            string FirstChoice = message.Substring(0, message.IndexOf("/"));
            message = message.Remove(0, message.IndexOf("/") + 1);
            Job Primary = JobFromString(FirstChoice);

            string SecondChoice = message.Substring(0, message.IndexOf("/"));
            message = message.Remove(0, message.IndexOf("/") + 1);
            Job Seconday = JobFromString(SecondChoice);

            string ThirdChoice = message.Substring(0, message.Length);
            Job Tertiary = JobFromString(ThirdChoice);

            if (Primary == Job.NoJob)
            {
                Primary = Job.WildCard;
            }
            if (Seconday == Job.NoJob)
            {
                Seconday = Job.WildCard;
            }
            if (Tertiary == Job.NoJob)
            {
                Tertiary = Job.WildCard;
            }

            Student NewStudent = new Student(LastName, FirstName, UserName, Primary, Seconday, Tertiary);

            return NewStudent;
        }

        /// <summary>
        /// Creates a job from a string
        /// </summary>
        /// <param name="description">the job in string format</param>
        /// <returns>the job as an enum</returns>
        public Job JobFromString(string description)
        {
            if (description == WILD_CARD)
            {
                return Job.WildCard;
            }
            else if (description == PROGRAMMER)
            {
                return Job.Programming;
            }
            else if (description == ARTIST)
            {
                return Job.Art;
            }
            else if (description == DESIGNER)
            {
                return Job.Design;
            }

            return Job.NoJob;
        }

        /// <summary>
        /// Recieves a message from the server
        /// </summary>
        /// <param name="dat">the data passed by through the story</param>
        static void RecieveData(ref byte[] dat)
        {
            string message = ASCIIEncoding.ASCII.GetString(dat);

            if (message != null)
            {
                mStaticStrings.Add(message);
                //System.Diagnostics.Debug.WriteLine(mStaticStrings[mStaticStrings.Count - 1]);
                //System.Diagnostics.Debug.WriteLine(mStaticStrings.Count);
            }
     
            //Console.WriteLine(message);
            // m_Client.GetStream().Write(message);
        }

        /// <summary>
        /// Writes the sorted groups to a file
        /// </summary>
        public void WriteGroupsToFile()
        {
            TextWriter textWriter = new StreamWriter("CapstoneGroups.txt");

            foreach (Group group in mGroupList.Values)
            {
                textWriter.WriteLine(group.GroupNumber);

                foreach (Student student in group.GroupMembers)
                {
                    textWriter.WriteLine(student.LastName + ", " + student.FirstName + ", " + student.EmailID);
                }

                textWriter.WriteLine(" ");
            }

            textWriter.Close();
        }

        #endregion

        #region Form Widget Events

        private void MainForm_GroupSizeCounter_ValueChanged(object sender, EventArgs e)
        {
            mGroupSize = (int)MainForm_GroupSizeCounter.Value;
            mGroupSizeSet = true;
        }

        private void MainForm_CreateButton_Click(object sender, EventArgs e)
        {
            if (mGroupSizeSet == false)
            {
                return;
            }

            CalculateNumberOfGroups();
            CreateGroups();

            // write to file
            WriteGroupsToFile();

            System.Diagnostics.Process.Start("CapstoneGroups.txt");
            
            MessageBox.Show("Groups Created", "Information");
            //foreach (Group G in mGroupList.Values)
            //{
            //    for (int i = 0; i < G.GroupSize; i++ )
            //    {
            //        if(G.GroupMembers[i].EmailID != null)
            //        {
            //            System.Diagnostics.Debug.WriteLine("Group: " + i + G.GroupMembers[i].EmailID);
            //        }
            //    }
            //}
        }

        private void MainForm_LaunchBallotsButton_Click(object sender, EventArgs e)
        {
            mVoteServer.Create();
            System.Diagnostics.Debug.WriteLine(Server.GetIP());
            mVoteServer.Traversal = RecieveData;
        }

        private void MainForm_CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
