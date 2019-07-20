using Xunit;

namespace CollectionsAndGenerics.Test
{
    public class GeneralRepositoryTest
    {

        GeneralRepository<User> repository;
        public GeneralRepositoryTest()
        {
            repository = new GeneralRepository<User>();
        }

        [Fact]
        public void Test_Insert()
        {
            var user1 = new User("firstname1", "lastname1", 1, "id1");
            var user2 = new User("firstname2", "lastname2", 2, "id2");
            repository.Insert(user1);
            repository.Insert(user2);


            Assert.Equal(2, repository.Count());
            Assert.Equal(user1, repository.GetByIdNumber("id1"));
            Assert.Equal(user2, repository.GetByIdNumber("id2"));
        }


        [Fact]
        public void Test_GetByIdNumber()
        {
            var user1 = new User("firstname1", "lastname1", 1, "ida");
            var user2 = new User("firstname2", "lastname2", 2, "idb");
            var user3 = new User("firstname3", "lastname3", 3, "idc");

            repository.Insert(user3);
            repository.Insert(user2);
            repository.Insert(user1);

            Assert.Equal(user1, repository.GetByIdNumber("ida"));
            Assert.Equal(user2, repository.GetByIdNumber("idb"));
            Assert.Equal(user3, repository.GetByIdNumber("idc"));
            Assert.Null(repository.GetByIdNumber("none"));
        }
    }
}
