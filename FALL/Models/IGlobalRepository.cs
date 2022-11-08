namespace FALL.Models
{
    public interface IGlobalRepository
    {
        public IEnumerable<Global> GetAllGlobals();
        public Global GetGlobal(long id);
        public void InsertGlobal (Global globalToInsert);
        public void UpdateGlobal(Global globalToUpdate);
        public void DeleteGlobal (Global global);

    }
}
