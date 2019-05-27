// using UnityEditor;
// using System;
// using System.IO;
// using System.Data;
// using Mono.Data.Sqlite;
using SQLite;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DatabaseConnector : MonoBehaviour
{
    public static DatabaseConnector instance;
    private const string fileName = "database.sqlite.bytes";
    private static string DBPath;
    private static SQLiteConnection connection;
    // private static SqliteCommand command;
    public DatabaseConnector()
    {    

        DBPath = Path.Combine(Application.streamingAssetsPath, fileName);
        if(!File.Exists(DBPath)) UnpackDatabase(DBPath);
        Debug.Log(DBPath);

        // return DatabaseConnector;
    }

    public static void OpenConnection()
    {
        // connection = new SQLiteConnection("Data Source=" + DBPath);
        // command = new SqliteCommand(connection);
        // connection.Open();
        Debug.Log("Connection opened");
        connection = new SQLiteConnection(DBPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        // Debug.Log("Final PATH: " + DBPath);

    }

    private static void UnpackDatabase(string toPath)
    {
        string fromPath = Path.Combine(Application.streamingAssetsPath, fileName);

        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(toPath, reader.bytes);
    }

    public static void CloseConnection()
    {
        Debug.Log("Connection closed");
        connection.Close();
        // command.Dispose();
    }

    public AcupointData[] getData() {

        // var list = connection.Table<AcupointData>();
        // Debug.Log("-=getData=- " + list.GetType());

        // return list.ToArray();

        var q = from f in connection.Table<AcupointData>() 
                where f.pos2d_x == 0
                select f;
	    return q.ToArray();

        // var q = from f in c.Table<Favorite>() select f;
	    // return q.ToArray();
    }

    public List<AcupointData> getAcupointsDataList(){

        Debug.Log("List acupoints data");
		return connection.Table<AcupointData>().ToList();
	}

    public List<MeridianData> getMeridiansDataList(){

        Debug.Log("List acupoints data");
		return connection.Table<MeridianData>().ToList();
	}

    public IEnumerable<AcupointData> getAcupointsData(){

        Debug.Log("Some acupoints data");
		return connection.Table<AcupointData>();
	}

    public int InsertAcupoint(AcupointData _point)
    {
        connection.Insert(_point);

        // SQLiteCommand command = new SQLiteCommand(connection);
        // command.CommandText = "SELECT last_insert_rowid()";
        // int index = connection.Execute("SELECT last_insert_rowid()");
        int index = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
        // int index = command.ExecuteNonQuery();
        // int index = command.ExecuteScalar<AcupointData>();

        // using (SqlConnection conn = new SqlConnection(connString))
        // {
            // string sql = "SELECT last_insert_rowid()";
            // SqlCommand cmd = new SqlCommand(sql, conn);
            // conn.Open();
            // int lastID = (Int32) cmd.ExecuteScalar();
        // }
        return index;
    }

    public void UpdateAcupoint(AcupointData _point)
    {
        // Debug.Log("ACUPOINT UPDATED");
        connection.Update(_point);
    }

    void Awake() {

        if (instance != null) {
            Debug.Log("Instance already exist");
            return;
        }
        else {
            instance = this;
            OpenConnection();     
        }
    }

    void OnDestroy() {
        CloseConnection();
    }

    public void CreateDB() {

		connection.DropTable<AcupointData> ();
		connection.CreateTable<AcupointData> ();

		connection.InsertAll (new[]{
			new AcupointData {
				id = 1,
				name = "LU2",
				description = "Acupoint LU2",
                pos2d_x = 5,
                pos2d_y = -5,
                pos3d_x = 10,
                pos3d_y = 10,
                pos3d_z = 10,
                meridian_id = 1,
			},
			new AcupointData {
				id = 2,
				name = "SI7",
				description = "Acupoint SI7",
				pos2d_x = -5,
                pos2d_y = 5,
                pos3d_x = 0,
                pos3d_y = 0,
                pos3d_z = 0,
                meridian_id = 6,
			}
		});
    }   

    public void CreateMeridianTable() {

		connection.DropTable<MeridianData> ();
		connection.CreateTable<MeridianData> ();

		connection.InsertAll (new[]{
			new MeridianData {
				id = 1,
                code = "LU",
				name = "Lung",
				description = "",
                pointsAmount = 11
			},
			new MeridianData {
				id = 2,
                code = "LI",
				name = "Large Intestine",
				description = "",
                pointsAmount = 20
			},
			new MeridianData {
				id = 3,
                code = "ST",
				name = "Stomach",
				description = "",
                pointsAmount = 45
			},
			new MeridianData {
				id = 4,
                code = "SP",
				name = "Spleen",
				description = "",
                pointsAmount = 21
			},
			new MeridianData {
				id = 5,
                code = "HT",
				name = "Heart",
				description = "",
                pointsAmount = 9
			},
            new MeridianData {
				id = 6,
                code = "SI",
				name = "Small Intestine",
				description = "",
                pointsAmount = 19
			},
            new MeridianData {
				id = 7,
                code = "BL",
				name = "Bladder",
				description = "",
                pointsAmount = 67
			},
            new MeridianData {
				id = 8,
                code = "KI",
				name = "Kidney",
				description = "",
                pointsAmount = 27
			},            
            new MeridianData {
				id = 9,
                code = "PC",
				name = "Pericardium",
				description = "",
                pointsAmount = 9
			},
            new MeridianData {
				id = 10,
                code = "TE",
				name = "Triple Energizer",
				description = "",
                pointsAmount = 23
			},
            new MeridianData {
				id = 11,
                code = "GB",
				name = "Gallbladder",
				description = "",
                pointsAmount = 44
			},
            new MeridianData {
				id = 12,
                code = "LR",
				name = "Liver",
				description = "",
                pointsAmount = 14
			},
            new MeridianData {
				id = 13,
                code = "GV",
				name = "Governor Vessel",
				description = "",
                pointsAmount = 28
			},
            new MeridianData {
				id = 14,
                code = "CV",
				name = "Conception Vessel",
				description = "",
                pointsAmount = 24
			},
		});
    }   
}