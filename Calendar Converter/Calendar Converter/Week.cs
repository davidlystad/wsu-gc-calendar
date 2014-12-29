﻿//  Copyright 2014 Washington State University

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_Converter
{
    class Week
    {
        private int memWeekNumber;
        private DateTime memWeekStart;
        private DateTime memWeekEnd;
        private bool memIsBreak;

        public Week(DateTime SemesterStart, int WeekNumber, bool IsBreak)
        {
            memWeekNumber = WeekNumber;
            memWeekStart = SemesterStart.Date.AddDays((WeekNumber - 1) * 7);
            memWeekEnd = memWeekStart.AddDays(7);
            memIsBreak = IsBreak;
        }

        public int WeekNumber
        {
            get { return memWeekNumber; }
        }

        public DateTime WeekStart
        {
            get{ return memWeekStart; }
        }

        public DateTime WeekEnd
        {
            get { return memWeekEnd; }
        }

        public bool IsBreak
        {
            get { return memIsBreak; }
            set { memIsBreak = value; }
        }

        public List<string> Dates
        {
            get
            {
                DateTime currentDate = memWeekStart.Date;
                List<string> Dates = new List<string>();

                while(currentDate.CompareTo(memWeekEnd) <= 0)
                {
                    if (memIsBreak)
                    {
                        Dates.Add("Break");
                        currentDate = currentDate.AddDays(1);
                    }
                    else
                    {
                        Dates.Add(currentDate.ToShortDateString());
                        currentDate = currentDate.AddDays(1);
                    }
                }

                return Dates;
            }
        }
    }
}