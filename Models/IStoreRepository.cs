namespace SportStore.Models
{
    public interface IStoreRepository{
        //The IQueryable<T> interface is derived from the more familiar IEnumerable<T> interface and represents a collection of objects that can be queried, such as those managed by a database.
        //A class that depends on the IStoreRepository interface can obtain Product objects without needing to know the details of how they are stored or how the implementation class will deliver them.
        IQueryable<Product> Products {get;}
    }
}