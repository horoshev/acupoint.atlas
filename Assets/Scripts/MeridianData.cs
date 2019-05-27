using SQLite;
using UnityEngine;
using System.Collections.Generic;

// Модель данных меридиана
// Используется для работы с хранилищем SQLite

public class MeridianData
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string code { get; set; } // Обозначение меридиана
    public string name { get; set; } // Название меридиана
    public string description { get; set; } // Описание меридиана
    public int pointsAmount { get; set; } // Количество точек на меридиане
    
    public override string ToString()
    {
        return string.Format("id = {0} name = {1} description = {2}", id, name, description);
    }
}