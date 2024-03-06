using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "La longueur doit être entre 3 caractères")]
        [MaxLength(25, ErrorMessage = "La longueur doit être entre 25 caractères")]
        //[StringLength(25, MinimumLength = 3, ErrorMessage = "La longueur doit être entre 3 et 25 caractères")]
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
