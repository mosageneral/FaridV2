using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IO;
using Farid.Domains.LMS;
using Farid.DTOs;
using Farid.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.LMS
{
    public class TestimonialsAppService : CrudAppService<Testimonials, TestimonialsDto>
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IFileHelper fileHelper;

        public TestimonialsAppService(IHostingEnvironment hostingEnvironment, IFileHelper fileHelper, IRepository<Testimonials, int> repository) : base(repository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.fileHelper = fileHelper;
        }
        public async Task Testimonials([FromForm] CreateTestimonialsDto TestimonialsDTO)
        {
            var ImageName = await fileHelper.UploadFile(TestimonialsDTO.Image, hostingEnvironment);

            var Testimonials = new Testimonials
            {

                Image = ImageName,

                Describtion = TestimonialsDTO.Describtion,
                Name = TestimonialsDTO.Name,
                Title = TestimonialsDTO.Title,


            };
            var Id = await Repository.InsertAndGetIdAsync(Testimonials);
        }
        public async Task UpdateTestimonials([FromForm] UpdateTestimonialsDto dto)
        {

            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var oldTestimonials = Repository.Get(dto.Id);
            if (oldTestimonials == null)
            {
                throw new ArgumentException("Testimonials not found", nameof(dto.Id));
            }

            var imagePath = await UploadFileIfNeeded(dto.Image, oldTestimonials.Image);


            // Update the old Testimonials with new paths
            oldTestimonials.Image = imagePath;


            oldTestimonials.Describtion = dto.Describtion;
            oldTestimonials.Title = dto.Title;
            oldTestimonials.Name = dto.Name;




            // Save changes to the repository
            await Repository.UpdateAsync(oldTestimonials);
        }
        private async Task<string> UploadFileIfNeeded(IFormFile file, string existingPath)
        {
            return file != null ? await fileHelper.UploadFile(file, hostingEnvironment) : existingPath;
        }
    }
}
