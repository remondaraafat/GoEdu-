namespace GoEdu.Repositories
{
    public interface ICRUD<T>
    {
        public void Insert(T Entity);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetByID(int id);
        public void Update(int id, T Entity);
        public void Delete(T Entity);
        public void SaveData();
    }
}
