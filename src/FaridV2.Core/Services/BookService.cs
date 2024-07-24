using Abp.Dependency;
using Abp.Domain.Repositories;
using FaridV2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaridV2.Services
{
    public interface IBookService
    {
        Task<List<Appointment>> GetAppointmentsAsync();
    }
    public class BookService : IBookService, ITransientDependency
    {
        private readonly IRepository<Appointment> appointmentRepo;

        public BookService(IRepository<Appointment> AppointmentRepo)
        {

            appointmentRepo = AppointmentRepo;
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return await appointmentRepo.GetAllListAsync();
        }
    }
}
