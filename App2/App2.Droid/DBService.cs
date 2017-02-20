using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2;
using Mono.Data.Sqlite;
using SQLite;
using System.IO;

namespace App2.Droid
{
    class DBService : DataBaseService
    {
        private SQLite.SQLiteConnection _connection;

        public string FullPath
        {
            get
            {
                if (string.IsNullOrEmpty(fullPath))
                {
                    fullPath = System.IO.Path.Combine(Path, FileName);
                }
                return fullPath;
            }
        }

        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(path))
                {
                    path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return path;
            }
        }


        public override SQLite.SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (!File.Exists(FullPath))
                    {
                        RemoveDBFiles(Path);
                        // create a write stream
                        FileStream writeStream = new FileStream(FullPath, FileMode.OpenOrCreate, FileAccess.Write);
                        // write to the stream
                        ReadWriteStream(new System.IO.MemoryStream(), writeStream);
                    }

                    _connection = new SQLiteConnection(FullPath, false);

                }

                return _connection;
            }
        }


        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = "Triathlon.db3";
                }

                return fileName;
            }
        }


        private string fullPath = null;
        private string fileName = null;
        private string path = null;

        public DBService() : base()
        {

        }

        protected void RemoveDBFiles(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                var files = Directory.GetFiles(path, "*.db3");


                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// helper method to get the database out of /raw/ and into the user filesystem
        /// </summary>
        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}