﻿using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BFloor
    {
        public static Object GetFloorsBySchool(int schoolID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var floors = db.TblFloors.Where(x => x.SchoolFK == schoolID).ToList();
                    if (floors.Count() == 0) { return null; }
                    return floors;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetFloor(int floorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblFloors.Find(floorID);
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateFloor(TblFloors floor)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblFloors.Add(floor);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditFloor(TblFloors floor)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(floor).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteFloor(int floorid)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var floor = db.TblFloors.Find(floorid);
                    db.TblFloors.Remove(floor);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
