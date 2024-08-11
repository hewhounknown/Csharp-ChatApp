using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Enums;

public enum CrudResults
{
    Success,
    Fail,
    AlreadyExisted,
    NotFound,
}
