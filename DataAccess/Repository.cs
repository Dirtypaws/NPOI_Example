using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Foundation.ObjectHydrator;
using Foundation.ObjectHydrator.Interfaces;
using NPOI.DataAccess.BusinessObjects;

namespace NPOI.DataAccess
{
    public class Repository
    {
        public static IEnumerable<Family> Get(int size = 25)
        {
            var families = new Hydrator<Family>()
                .WithCustomGenerator(x => x.Kids, new KidGenerator())
                .WithCustomGenerator(x => x.Mom, new Hydrator<Person>())
                .WithCustomGenerator(x => x.Dad, new Hydrator<Person>());
            
            var result = families.GetList(size);

            return result.ToList();
        }

    }

    public class KidGenerator : IGenerator<List<Person>>
    {
        private static Random _rnd;

        private static Random Rnd
        {
            get
            {
                if(_rnd == null)
                    _rnd = new Random();

                return _rnd;
            }
        }

        public List<Person> Generate()
        {
            var size = Rnd.Next(0, 7);
            var kids = new Hydrator<Person>();

            if (size == 0) return new List<Person>();

            var result = kids.GetList(size);

            return result.ToList();
        }
    }
}