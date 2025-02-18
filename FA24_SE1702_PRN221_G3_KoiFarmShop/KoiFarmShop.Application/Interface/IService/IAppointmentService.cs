﻿using KoiFarmShop.Application.Common.Result;
using KoiFarmShop.Infrastructure.DTOs.Appointment.MakeAppointment;

namespace KoiFarmShop.Application.Interface.IService
{
    public interface IAppointmentService
    {
        public Task<Result> MakeAppointmentForServiceAsync(MakeAppointmentForServiceRequest request);
        public Task<Result> MakeAppointmentForComboAsync(MakeAppointmentForComboRequest request);
        public Task<Result> GetAllAppointmentsAsync();
        public Task<Result> GetByIdAsync(Guid appointmentId);
        Task<Result> GetAppointmentsByUserIdAsync(Guid userId);

        Task<Result> UpdateAppointmentAsync(Guid appointmentId, MakeAppointmentForServiceRequest request);

        Task<Result> DeleteAppointmentAsync(Guid appointmentId);

    }
}
