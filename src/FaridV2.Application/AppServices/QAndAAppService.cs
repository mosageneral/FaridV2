using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Farid.Authorization.Users;
using Farid.Domains.LMS;
using Farid.DTOs;
using Farid.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.LMS
{

    public class QAndAAppService : CrudAppService<QAndA, QAndADto>
    {
        public QAndAAppService(IRepository<QAndA, int> repository) : base(repository)
        {
        }
        public override PagedResultDto<QAndADto> GetAll(PagedAndSortedResultRequestDto input)
        {

            var d = base.GetAll(input);
            d.Items.OrderByDescending(a => a.Id);
            return d;
        }



    }
}
