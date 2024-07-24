using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Farid.Domains.LMS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.DTOs
{

    [AutoMap(typeof(InternalPages))]
    public class InternalPagesDto : EntityDto
    {

        public string Image { get; set; }
        public string Title { get; set; }
        public string slug { get; set; }
        public string Describtion { get; set; }
    }
    public class CreateInternalPagesDto
    {

        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string slug { get; set; }
        public string Describtion { get; set; }
    }
    public class UpdateInternalPagesDto
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string slug { get; set; }
        public string Describtion { get; set; }
    }

}
