using web.Models;

namespace web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ����������
            using (PhoneDBContext db = new PhoneDBContext())
            {
                if (!db.Phones.Any() && !db.Brands.Any())
                {
                    Phone ph1 = new Phone { Model = "������-������", Price = 12600, BrandId = 6 };
                   
                    Phone ph3 = new Phone { Model = "������", Price = 132500, BrandId = 8 };
                    Phone ph4 = new Phone { Model = "����������� ����������", Price = 87640, BrandId = 7 };
               
                    Brand br1 = new Brand { Name = "������", Country = "������" };
                    Brand br2 = new Brand { Name = "���������", Country = "���������" };
               
                    Brand br4 = new Brand { Name = "�������", Country = "�������� �������" };
                    Brand br5 = new Brand { Name = "��������", Country = "����� �������" };
                    Brand br6 = new Brand { Name = "������", Country = "������" };
                    Brand br7 = new Brand { Name = "���������", Country = "����� �������" };
                    Brand br8 = new Brand { Name = "������", Country = "�������� �������" };
                    Brand br9 = new Brand { Name = "�������", Country = "������" };


                    // ����������

                    db.Brands.Add(br1);
                    db.Brands.Add(br2);
                    
                    db.Brands.Add(br4);
                    db.Brands.Add(br5);
                    db.Brands.Add(br6);
                    db.Brands.Add(br7);
                    db.Brands.Add(br8);
                    

                    db.Phones.Add(ph1);
                    
                    db.Phones.Add(ph3);
                    db.Phones.Add(ph4);
                    
                }
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
