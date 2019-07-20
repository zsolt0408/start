namespace CollectionsAndGenerics
{
    public class User: IStorable
    {
        public string Firstname;
        public string Lastname;
        public int Age;
        public string Id { get; set; }

        public User(string firstname, string lastname, int age, string id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Id = id;
        }
    }
}
