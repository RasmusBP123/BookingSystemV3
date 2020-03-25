using AutoMapper;
using Domain.Entities;
using rbp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application._Common.Mappings
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Calendar, CalendarViewModel>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(dest => dest.Name.Value));
            CreateMap<Timeslot, TimeslotViewModel>()
                .ForMember(dto => dto.From, opt => opt.MapFrom(dest => dest.Range.From))
                .ForMember(dto => dto.To, opt => opt.MapFrom(dest => dest.Range.To));
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dto => dto.From, opt => opt.MapFrom(dest => dest.Range.From))
                .ForMember(dto => dto.To, opt => opt.MapFrom(dest => dest.Range.To)); ;
        }
    }
}
