using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; } // each technology belongs to one ProgrammingLanguage

        public Technology()
        {

        }

        public Technology(int id, int programmingLanguageId, string name)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
