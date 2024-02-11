namespace Mediag.Medical
{
    class Hospital
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public Hospital() { }

        public Hospital(long id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
