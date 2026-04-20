using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Galaxy News!");
            IterateThroughList();
            Console.ReadKey();
        }

        /// <summary>
        /// Создаёт список галактик и выводит информацию о каждой из них в консоль.
        /// Использует коллекцию List<Galaxy> и цикл foreach для перебора.
        /// </summary>
        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name="Tadpole", MegaLightYears=400, GalaxyType=new GType('S')},
            new Galaxy() { Name="Pinwheel", MegaLightYears=25, GalaxyType=new GType('S')},
            new Galaxy() { Name="Cartwheel", MegaLightYears=500, GalaxyType=new GType('L')},
            new Galaxy() { Name="Small Magellanic Cloud", MegaLightYears=.2, GalaxyType=new GType('I')},
            new Galaxy() { Name="Andromeda", MegaLightYears=3, GalaxyType=new GType('S')},
            new Galaxy() { Name="Maffei 1", MegaLightYears=11, GalaxyType=new GType('E')}
        };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears + ",  " + theGalaxy.GalaxyType.MyGType);
            }
        }
    }

    /// <summary>
    /// Класс, представляющий одну галактику.
    /// Содержит основную информацию: название, расстояние в мега-световых годах и тип галактики.
    /// </summary>
    public class Galaxy
    {
        public string Name { get; set; }

        public double MegaLightYears { get; set; }
        public GType GalaxyType { get; set; }

    }

    /// <summary>
    /// Класс, который определяет тип галактики по одной букве-коду.
    /// Преобразует символ ('S', 'E', 'I', 'L') в понятное название типа.
    /// </summary>
    public class GType
    {
        /// <summary>
        /// Конструктор класса GType.
        /// Принимает один символ и в зависимости от него устанавливает тип галактики.
        /// Если символ неизвестен — тип не устанавливается (остаётся null).
        /// </summary>
        /// <param name="type">Символ-код типа галактики: 'S' — Spiral, 'E' — Elliptical, 'I' — Irregular, 'L' — Lenticular.</param>
        public GType(char type)
        {
            switch (type)
            {
                case 'S':
                    MyGType = Type.Spiral;
                    break;
                case 'E':
                    MyGType = Type.Elliptical;
                    break;
                case 'I':
                    MyGType = Type.Irregular;
                    break;
                case 'L':
                    MyGType = Type.Lenticular;
                    break;
                default:
                    break;
            }
        }
        public object MyGType { get; set; }
        private enum Type { Spiral, Elliptical, Irregular, Lenticular }
    }
}
