﻿using Autofac;
using AutoMapper;
using CoreplusExercise.Accessor.Practitioner.DOs;
using CoreplusExercise.Accessor.Practitioner.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace CoreplusExercise.Accessor.Practitioner.TypeMappings
{
    internal class LookupAppointmentTypeResolver : IValueResolver<AppointmentDO, AppointmentDTO, string>
    {
        string IValueResolver<AppointmentDO, AppointmentDTO, string>.Resolve(AppointmentDO source, AppointmentDTO destination, string destMember, ResolutionContext context)
        {
            using (var scope = AccessorAutofacContainer.Container.BeginLifetimeScope())
            {
                var logger = scope.Resolve<ILogger<LookupAppointmentTypeResolver>>();

                try
                {
                    var appointmentType = "";

                    switch (source.AppointmentType)
                    {
                        case 1:
                            appointmentType = "Visit";
                            break;
                        case 2:
                            appointmentType = "House visit";
                            break;
                        case 3:
                            appointmentType = "Full check-up";
                            break;
                        case 4:
                            appointmentType = "Check-up";
                            break;
                        default:
                            break;
                    }

                    return appointmentType;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error in LookupAppointmentTypeResolver");
                    throw;
                }
            }
        }
    }
}
