using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Mapping.Model
{
    public class EducationCategory
    {
        public int Id { get; set; }
        public int Priority { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
    }
}
