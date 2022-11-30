using Dapper;
using System.Data;

namespace FALL.Models
{
    public class GlobalRepository : IGlobalRepository
    {
        //Define Connection
        public GlobalRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        private readonly IDbConnection _conn;

        //Get Globals
        public IEnumerable<Global> GetAllGlobals()
        {
            return _conn.Query<Global>("SELECT * FROM GLOBALS;");
        }

        //Get singular Global
        public Global GetGlobal(long id)
        {
            return _conn.QuerySingle<Global>("SELECT * FROM GLOBALS WHERE UID = @id", new { id = id });
        }

        //Post Global
        public void InsertGlobal(Global globalToInsert)
        {
            _conn.Execute("INSERT INTO GLOBALS (UID, Name, Level, SelectedLegend, Skin, SkinRarity, Platform) VALUES (@uid, @name, @level, @selectedLegend, @skin, @skinRarity, @platform)", new
            {
                uid = globalToInsert.UID,
                name = globalToInsert.Name,
                level = globalToInsert.Level,
                selectedLegend = globalToInsert.SelectedLegend,
                skin = globalToInsert.Skin,
                skinRarity = globalToInsert.SkinRarity,
                platform = globalToInsert.Platform
            });
        }

        //Update Global
        public void UpdateGlobal(Global globalToUpdate)
        {
            _conn.Execute("UPDATE GLOBALS SET Name = @name, Level = @level, SelectedLegend = @selectedLegend, Skin = @skin, SkinRarity = @skinRarity " +
                "WHERE UID = @uid", new
            {
                    name = globalToUpdate.Name,
                    level = globalToUpdate.Level,
                    selectedLegend = globalToUpdate.SelectedLegend,
                    skin = globalToUpdate.Skin,
                    skinRarity = globalToUpdate.SkinRarity,
                    uid = globalToUpdate.UID
                });
        }

        //Delete Global
        public void DeleteGlobal(Global global)
        {
            _conn.Execute("DELETE FROM GLOBALS WHERE UID = @id;", new {id = global.UID});
        }

    }
}
