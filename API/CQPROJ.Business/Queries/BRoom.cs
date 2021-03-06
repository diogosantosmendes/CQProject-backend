﻿using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BRoom
    {
        public static Object GetRoomsBySchool(int schoolID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var floors = db.TblFloors.Where(y => y.SchoolFK == schoolID).ToList();
                    List<TblRooms> rooms = new List<TblRooms>();
                    foreach (var floor in floors)
                    {
                        rooms.Concat(db.TblRooms.Where(x => x.FloorFK == floor.ID).ToList());
                    }
                    if (rooms.Count() == 0) { return null; }
                    return rooms;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetRoomsByFloor(int floorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var rooms = db.TblRooms.Where(x => x.FloorFK == floorID).ToList();
                    if (rooms.Count() == 0) { return null; }
                    return rooms;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetRoom(int roomID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblRooms.Find(roomID);
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateRoom(TblRooms room)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblRooms.Add(room);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditRoom(TblRooms room)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(room).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteRoom(int roomid)
        {
            throw new NotImplementedException();
        }
    }
}
