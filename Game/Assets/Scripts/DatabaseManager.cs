using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DatabaseManager : MonoBehaviour
{
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    string DATABASE_NAME = "/GameSave.db";

    void Start()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        conn = "URI=file:" + filepath;
        dbconn = new SqliteConnection(conn);
        CreateTable();
    }

    private void CreateTable()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery =
                "CREATE TABLE IF NOT EXISTS Login ("
                + "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,"
                + "[name] VARCHAR(255)  NOT NULL,"
                + "[age] INTEGER DEFAULT '18' NOT NULL)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
}
