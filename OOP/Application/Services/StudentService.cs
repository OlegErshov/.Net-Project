using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
    }
}
