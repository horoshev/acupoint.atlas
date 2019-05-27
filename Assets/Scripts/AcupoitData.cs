using SQLite;
using UnityEngine;
using System.Collections.Generic;

// Модель данных точки
// Используется для работы с хранилищем SQLite

/*
CREATE TABLE acupoint_data(
  id INTEGER PRIMARY KEY,
  name TEXT NOT NULL,
  description TEXT NOT NULL,
  pos2d_x FLOAT NOT NULL,
  pos2d_y FLOAT NOT NULL,
  pos3d_x FLOAT NOT NULL,
  pos3d_y FLOAT NOT NULL,
  pos3d_z FLOAT NOT NULL
);

CREATE TABLE notes(
  id INTEGER PRIMARY KEY,
  id_acupoint type NOT NULL,
  note TEXT NOT NULL,
  created_at DATETIME NOT NULL DEFAULT (datetime('now','localtime')),
  updated_at DATETIME NOT NULL DEFAULT (datetime('now','localtime')),
  FOREIGN KEY(id_acupoint) REFERENCES acupoints(id)
);
*/

public class AcupointData
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; } // Название точки
    public string description { get; set; } // Описание точки
    public float pos2d_x { get; set; } // Позиция x точки на картинке
    public float pos2d_y { get; set; } // Позиция y точки на картинке
    public float pos3d_x { get; set; } // // Позиция x точки на объемной модели
    public float pos3d_y { get; set; } // // Позиция y точки на объемной модели
    public float pos3d_z { get; set; } // // Позиция z точки на объемной модели
    public int meridian_id { get; set; } // Внешний ключ на таблицу меридианов
  
    // public List<string> notes; // Пометки пользователя к точке
  
    // default acupoint data
    public AcupointData() {
        
        name = "unnamed point";
        description = "new acupoint";
        pos2d_x = pos2d_y = pos3d_z = 0;
        pos3d_x = pos3d_y = 10;
        meridian_id = 0;
    }
  
    public override string ToString()
    {
        return string.Format("id = {0} name = {1} description = {2}", id, name, description);
    }
}