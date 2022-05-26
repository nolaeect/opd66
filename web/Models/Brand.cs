namespace web.Models
{
    public class Brand
    {
        public Brand() => Phones = new HashSet<Phone>();

        public int Id { get; set; }
        public string Name { get; set; } // название бренда
        public string Country { get; set; }

        //public List<Phone> Phones { get; set; } // у одного бренда может быть много разных моделей телефона

        public ICollection<Phone> Phones { get; set; }


    }
}
