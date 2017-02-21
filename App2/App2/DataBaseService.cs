using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using System.Collections;

namespace App2
{
    class DataBaseService
    {
        private static DataBaseService instance;
        public static DataBaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                            instance = new DataBaseService();
                    }
                }

                return instance;
            }
        }
        static object locker = new object();

        public virtual SQLiteConnection Connection
        {
            get; set;
        }

        public DataBaseService()
        {
           // CreateDB();
        }

        public void CreateDB()
        {
            CreateTable<TriathlonTraining>();

            // CreateTableWithName("LocationPoint", typeof(LocationPoint).Name);
        }

        public void CreateTable<T>()
        {
            lock (locker)
            {
                Connection.CreateTable<T>();
            }
        }

        public void CreateTableWithName(string name, string type)
        {
            try
            {
                lock (locker)
                {
                    var statement = @"CREATE TABLE IF NOT EXISTS " + name + " AS SELECT * FROM " + type + " WHERE 1=0";
                    var cmd = Connection.CreateCommand(statement);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine("Create failed: " + ex.Message);
                throw ex;
            }
        }


        public IEnumerable<T> Select<T>(String statement)
            where T : new()
        {
            lock (locker)
            {
                var cmd = Connection.CreateCommand(statement);
                var result = cmd.ExecuteQuery<T>();
                return result;
            }
        }

        public void Delete(string statement)
        {
            try
            {
                lock (locker)
                {
                    var cmd = Connection.CreateCommand(statement);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine("Deletion failed: " + ex.Message);
                throw ex;
            }
        }

        //public void GetUGState(ref string userId, out bool completed)
        //{
        //    completed = false;

        //    string sqlRequest = string.Format(@"SELECT Id,Completed FROM UGCompletionSource where Id = '{0}'", userId);
        //    var list = Select<UGCompletionSource>(sqlRequest).ToList();

        //    if (list.Count == 0)
        //    {
        //        Dictionary<string, object> fields = new Dictionary<string, object>();

        //        fields.Add("Id", userId);
        //        fields.Add("Completed", 0);

        //        Insert("UGCompletionSource", fields);
        //    }
        //    else
        //    {
        //        var ugcs = list[0];

        //        completed = Convert.ToBoolean(ugcs.Completed);
        //    }
        //}

        //public void SetUGState(ref string userId, ref bool completed)
        //{
        //    int c = Convert.ToInt32(completed);

        //    string sqlRequest = string.Format(@"SELECT Id,Completed FROM UGCompletionSource where Id = '{0}'", userId);
        //    var list = Select<UGCompletionSource>(sqlRequest).ToList();

        //    if (list.Count == 0)
        //    {
        //        Dictionary<string, object> fields = new Dictionary<string, object>();

        //        fields.Add("Id", userId);
        //        fields.Add("Completed", c);

        //        Insert("UGCompletionSource", fields);
        //    }
        //    else
        //    {
        //        sqlRequest = string.Format(@"UPDATE UGCompletionSource SET Completed = {1} where Id = '{0}'", userId, c);
        //        var cmd = Connection.CreateCommand(sqlRequest);
        //        cmd.ExecuteScalar<string>();
        //    }
        //}

        public void GetUsers()
        {

        }


        //public void InsertOrReplaceAll(IEnumerable collection, string tableName)
        //{
        //    foreach (var item in collection)
        //    {
        //        Dictionary<string, object> fields = new Dictionary<string, object>();

        //        if (item is LocationPoint)
        //        {
        //            var location = item as LocationPoint;
        //            fields.Add("PositionDate", location.PositionDate);
        //            fields.Add("Lat", location.Lat);
        //            fields.Add("Lon", location.Lon);
        //            fields.Add("Height", location.Height);
        //            fields.Add("Accuracy", location.Accuracy);
        //            fields.Add("Speed", location.Speed);
        //            fields.Add("BatteryStatus", location.BatteryStatus);
        //        }

        //        //if (item is StatisticItem)
        //        //{
        //        //    var statisticItem = item as StatisticItem;
        //        //    fields.Add("Id", statisticItem.Id.ToString());
        //        //    fields.Add("Date", statisticItem.Date.ToString());
        //        //    fields.Add("ItemId", statisticItem.ItemId);
        //        //    fields.Add("Type", statisticItem.Type);
        //        //}

        //        Insert(tableName, fields);
        //    }
        //}


        public void SaveTrinathlonTraining(TriathlonTraining item)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();
                    
            fields.Add("Date", item.Date);
            fields.Add("Distance", item.Distance);
            fields.Add("Time", item.Time);
            fields.Add("Type", item.Type);
        }

        void InsertIntoTable(Dictionary<string, object> fields)
        {
            try
            {
                lock (locker)
                {
                    var statement = "INSERT INTO TriathlonTable";
                    var fieldsToInsert = " (";
                    var valuesToInsert = " (";

                    foreach (KeyValuePair<string, object> o in fields)
                    {
                        fieldsToInsert += o.Key + ",";
                        valuesToInsert += "@" + o.Key + ",";
                    }
                    fieldsToInsert = fieldsToInsert.Substring(0, fieldsToInsert.Length - 1) + ") ";
                    valuesToInsert = valuesToInsert.Substring(0, valuesToInsert.Length - 1) + ") ";
                    statement += fieldsToInsert + " VALUES " + valuesToInsert;

                    var cmd = Connection.CreateCommand(statement);
                    foreach (KeyValuePair<string, object> o in fields)
                    {
                        cmd.Bind("@" + o.Key, o.Value);
                    }
                    cmd.ExecuteScalar<string>();
                }
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine("Insert failed: " + ex.Message);
                throw ex;
            }
        }
        #region LocationPoints

        public IEnumerable<TriathlonTraining> GetTriathlonTrainings()
        {
            string sqlRequest = @"SELECT * FROM TriathlonTable";
            var list = Select<TriathlonTraining>(sqlRequest);
            return list;
        }

        public TriathlonTraining GetTriathlonTrainingById(int id)
        {
            string sqlRequest = @"SELECT * FROM TriathlonTable WHERE id == " + id.ToString();
            var list = Select<TriathlonTraining>(sqlRequest);
            return list != null && (list as List<TriathlonTraining>).Count > 0 ? (list as List<TriathlonTraining>)[0]
                : new TriathlonTraining();
        }

        //public void SetLocationPoints(IList<LocationPoint> locationPoints)
        //{

        //    if (locationPoints != null)
        //    {
        //        InsertOrReplaceAll(locationPoints, "LocationPoint");

        //        Debug.WriteLine("Loaded LocationPoints " + locationPoints.Count);
        //    }
        //}

        public void ClearLocationPoints()
        {
            Delete(@"DELETE FROM TriathlonTable");
        }



        #endregion

        //#region UsageStatistics

        //public IEnumerable<StatisticItem> GetUsageStatistics()
        //{
        //    string sqlRequest = @"SELECT * FROM StatisticItem";
        //    var list = Select<StatisticItem>(sqlRequest);
        //    return list;

        //}

        //public void SetUsageStatistics(IList<StatisticItem> statisticItems)
        //{
        //    for (int i = 0; i < statisticItems.Count; i++)
        //    {
        //        var statisticItem = statisticItems[i];
        //        string sqlRequest = string.Format(@"SELECT Id FROM StatisticItem where Id = '{0}'", statisticItem.Id);
        //        var list = Select<StatisticItem>(sqlRequest).ToList();

        //        if (list.Count == 0)
        //        {
        //            Dictionary<string, object> fields = new Dictionary<string, object>();

        //            fields.Add("Id", statisticItem.Id.ToString());
        //            fields.Add("Date", statisticItem.Date);
        //            fields.Add("ItemId", statisticItem.ItemId);
        //            fields.Add("Type", statisticItem.Type);

        //            Insert("StatisticItem", fields);

        //        }
        //    }

        //}

        //public void ClearUsageStatistics()
        //{
        //    Delete(@"DELETE FROM StatisticItem");
        //}
        //#endregion
    }
}
