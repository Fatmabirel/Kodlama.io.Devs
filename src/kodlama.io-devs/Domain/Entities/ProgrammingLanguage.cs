using Core.Persistence.Repositories;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }

        public ProgrammingLanguage() //varsayılan-parametresiz constructor
        {
        }

        public ProgrammingLanguage(int id, string name) : this()  //name-id değerlerini alan ve this ile varsayılan constructor'ı çağıran parametreli constructor
        {
            Id = id;
            Name = name;
        }
    }
}
