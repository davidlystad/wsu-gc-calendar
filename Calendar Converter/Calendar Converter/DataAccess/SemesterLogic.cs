﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_Converter.Model;
using System.Collections.ObjectModel;

namespace Calendar_Converter.DataAccess
{
    public class SemesterLogic
    {
        private List<Semester> memSemesters;

        public SemesterLogic()
        {
            memSemesters = new List<Semester>();
        }

        public List<Semester> Semesters
        {
            get { return memSemesters; }
        }

        public void NewSemesters(DateTime OldStart, DateTime NewStart, int Length, bool UseBreaks)
        {
            memSemesters = new List<Semester>();
            memSemesters.Add(Semester.CreateSemester(OldStart, Length, UseBreaks, PopulateWeeks(OldStart, Length, UseBreaks)));

            memSemesters.Add(Semester.CreateSemester(NewStart, Length, UseBreaks, PopulateWeeks(NewStart, Length, UseBreaks)));
        }

        private List<Week> PopulateWeeks(DateTime Start, int Length, bool HasBreaks)
        {
            List<Week> Weeks = new List<Week>();
            List<Break> Breaks = null;

            while (Start.DayOfWeek != DayOfWeek.Monday)
            {
                Start = Start.AddDays(-1); //This moves the date placement back to Monday to give correct start of week. 
            }

            if(HasBreaks)
            {
                Breaks = BreakDates.NewBreak(Start);
            }

            for(int i = 0; i < Length; i++)
            {
                bool isBreak = false;
                foreach(Break _break in Breaks)
                {
                    if(_break.Start == Start.AddDays(7*i))
                    {
                        Weeks.Add(_break);
                        isBreak = true;
                    }
                }
                if (!isBreak)
                {
                    Weeks.Add(Week.CreateWeek(Start.AddDays(7 * i)));
                }
            }

            return Weeks;
        }
    }
}