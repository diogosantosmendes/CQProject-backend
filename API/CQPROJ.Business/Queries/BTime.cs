﻿using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BTime
    {
        public static Object GetTimeBySchool(int schoolID, bool isKindergarten)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var time = db.TblTimes.Where(x => x.SchoolFK == schoolID && x.IsKindergarten== isKindergarten).ToList();
                    if (time.Count() == 0) { return null; }
                    return time;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetTime(int timeID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblTimes.Find(timeID);                }
            }
            catch (Exception) { return null; }
        }

        public static bool CreateTime(TblTimes time)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblTimes.Add(time);
                    db.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool EditTime(TblTimes time)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(time).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteTime(int timeid)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var time = db.TblTimes.Find(timeid);
                    db.TblTimes.Remove(time);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
