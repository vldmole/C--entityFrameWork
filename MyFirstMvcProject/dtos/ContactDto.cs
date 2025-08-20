using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMvcProject.dtos
{
    public record ContactDto(
        string Name,
        string Phone,
        string Email
    );
}