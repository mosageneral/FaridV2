using Abp.Application.Services;
using Abp.Domain.Repositories;
using Farid.Domains.LMS;
using Farid.DTOs;
using Farid.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.LMS
{
    public class SlidesAppService : CrudAppService<Slide, SlideDto>
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IFileHelper fileHelper;

        public SlidesAppService(IHostingEnvironment hostingEnvironment, IFileHelper fileHelper, IRepository<Slide, int> repository) : base(repository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.fileHelper = fileHelper;
        }
        public async Task AddSlide([FromForm] CreateSlideDto SlideDTO)
        {
            var ImageName = await fileHelper.UploadFile(SlideDTO.Image, hostingEnvironment);

            var Slide = new Slide
            {

                Image = ImageName,
                Describtion = SlideDTO.Describtion,
                Title = SlideDTO.Title,


            };
            var Id = await Repository.InsertAndGetIdAsync(Slide);
        }

    }
}
