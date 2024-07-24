using FaridV2.Domains;
using FaridV2.DTO;
using FaridV2.Features;
using FaridV2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.AppServices
{
    public class AppointmentAppService : FaridV2AppServiceBase
    {
        private readonly IFileHelper fileHelper;
        private readonly IBookService bookService;

        public AppointmentAppService(IFileHelper fileHelper, IBookService bookService)
        {
            this.fileHelper = fileHelper;
            this.bookService = bookService;
        }

        public async Task<string> UploadAppointment([FromForm] UploadFileDto dto)
        {
            var FileResult = await fileHelper.UploadFile(dto.File);
            return FileResult;
        }
    }
}
