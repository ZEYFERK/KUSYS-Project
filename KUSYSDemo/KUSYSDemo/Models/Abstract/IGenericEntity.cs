namespace KUSYSDemo.Models.Abstract
{
    public interface IGenericEntity<T> where T : class
    {
        public void Insert(T t);
        public void Delete(T t);
        public void Update(T t);
        public List<T> GetAll();
        public T GetById(int Id);


    }
}
