using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IPromotionService
    {
        Task<bool> PromoteInCampusStudentAsync(InCampusStudent student);
    }
}
