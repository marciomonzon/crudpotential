using CrudDesenvolvedores.Dados;
using Microsoft.EntityFrameworkCore;

namespace CrudDesenvolvedoresTeste
{
    public class ApplicationContextTest
    {
        public static DesenvolvedorContext GetContext()
        {
            var options = new DbContextOptionsBuilder<DesenvolvedorContext>().UseInMemoryDatabase("DatabaseTeste").Options;
            var context = new DesenvolvedorContext(options);
            return context;
        }

        ///// <summary>
        ///// For use automapper, this  mandatory class mapping in this method
        ///// </summary>
        ///// <returns></returns>
        //public static IMapper GetMapping()
        //{
        //    var mapping = new MapperConfiguration(cfg =>
        //    {
        //        //cfg.AddProfile(new UserMappingDTO());
        //    });

        //    return mapping.CreateMapper();
        //}
    }
}
