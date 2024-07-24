using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IO;
using Abp.UI;
using Farid.Domains.LMS;
using Farid.DTOs;
using FaridV2.Features;
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
    public class InternalPagesAppService : CrudAppService<InternalPages, InternalPagesDto>
    {

        private readonly IFileHelper fileHelper;

        public InternalPagesAppService(IFileHelper fileHelper, IRepository<InternalPages, int> repository) : base(repository)
        {

            this.fileHelper = fileHelper;
        }
        public async Task CreateInternalPages([FromForm] CreateInternalPagesDto InternalPagesDTO)
        {
            var ImageName = await fileHelper.UploadFile(InternalPagesDTO.Image);

            var InternalPages = new InternalPages
            {

                Image = ImageName,

                Describtion = InternalPagesDTO.Describtion,
                slug = InternalPagesDTO.slug,
                Title = InternalPagesDTO.Title,


            };
            var Id = await Repository.InsertAndGetIdAsync(InternalPages);
        }
        public async Task<InternalPages> GetPageBySlug(string Slug)
        {
            var Page = await Repository.FirstOrDefaultAsync(a => a.slug == Slug);
            if (Page == null)
                throw new UserFriendlyException("No such page");

            return Page;


        }

        public async Task UpdateInternalPages([FromForm] UpdateInternalPagesDto dto)
        {

            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var oldInternalPages = Repository.Get(dto.Id);
            if (oldInternalPages == null)
            {
                throw new ArgumentException("InternalPages not found", nameof(dto.Id));
            }

            var imagePath = await UploadFileIfNeeded(dto.Image, oldInternalPages.Image);


            // Update the old InternalPages with new paths
            oldInternalPages.Image = imagePath;


            oldInternalPages.Describtion = dto.Describtion;
            oldInternalPages.Title = dto.Title;
            oldInternalPages.slug = dto.slug;




            // Save changes to the repository
            await Repository.UpdateAsync(oldInternalPages);
        }
        private async Task<string> UploadFileIfNeeded(IFormFile file, string existingPath)
        {
            return file != null ? await fileHelper.UploadFile(file) : existingPath;
        }
    }
}
