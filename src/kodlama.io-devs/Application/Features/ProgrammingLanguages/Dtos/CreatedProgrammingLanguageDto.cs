﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class CreatedProgrammingLanguageDto // returns dto after ProgrammingLanguage Entity created
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
