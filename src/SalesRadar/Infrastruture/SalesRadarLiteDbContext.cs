using LiteDB;
using Microsoft.Extensions.Options;
using SalesRadar.Common;
using System;

namespace SalesRadar.Infrastruture;

public class SalesRadarLiteDbContext
{
    public readonly LiteDatabase Context;
    public SalesRadarLiteDbContext(IOptions<LiteDbConfig> configs)
    {
        Context = new LiteDatabase(configs.Value.DatabasePath);
        //try
        //{
        //    var db = 
        //    if (db != null)
        //    {
        //        Context = db;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception("Can find or create LiteDb database.", ex);
        //}
    }
}