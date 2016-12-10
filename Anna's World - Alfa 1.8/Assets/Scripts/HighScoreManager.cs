using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour {
	
	private string connectionString;
    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scorePrefab;

	void Start()
	{
		connectionString = "URI=file:" + Application.dataPath + "/Usuarios.sqlite";
        insertScore("dASDasdasd ", "ewwwefasdfsd", 123);
        getScores();	
	}
	
	void Update(){
		
	}

    private void insertScore (string nombre, string contra, int nuevoScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO Usuario (User, Password, Score) VALUES (\"{0}\", \"{1}\" , \"{2}\")",nombre, contra, nuevoScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close(); 
                
                
            
        }
    }
}
	
	private void getScores(){

        highScores.Clear();
		using (IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();
			
			using (IDbCommand dbCmd = dbConnection.CreateCommand())
			{
                string sqlQuery = "SELECT * FROM Usuario"; 
				dbCmd.CommandText = sqlQuery;
				
				using (IDataReader reader = dbCmd.ExecuteReader())
				{
					while (reader.Read())
					{
                        highScores.Add(new HighScore(reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                    dbConnection.Close();
					reader.Close();
				}
			}
		}
	}

    private void showScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            GameObject tmpObjec = Instantiate(scorePrefab);

            HighScore tmpScore = highScores[i];

            tmpObjec.GetComponent<highscoreScript>().setScore(tmpScore.Usuario, tmpScore.Score, "#" +  (i + 1).ToString());
        }
    }

    /*private void getUser(){
		
	}*/

}