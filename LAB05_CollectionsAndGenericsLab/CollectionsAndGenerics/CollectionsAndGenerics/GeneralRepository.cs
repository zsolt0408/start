using System.Collections.Generic;

namespace CollectionsAndGenerics
{
    public class GeneralRepository<T> where T: IStorable
    {
        private Dictionary<string, T> entities = new Dictionary<string, T>();

        public GeneralRepository()
        {
        }

        public int Count()
        {
            return entities.Count;
        }

        public void Insert(T entity)
        {
            entities.Add(entity.Id, entity);
        }

        public T GetByIdNumber(string id)
        {
            T entity = default(T);
            if(entities.TryGetValue(id, out entity))
            {
                return entity;
            }

            return default(T);
        }
    }
}
