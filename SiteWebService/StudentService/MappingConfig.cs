using System;
using AutoMapper;
using StudentService.Models;
using StudentService.Models.Dtos;

namespace StudentService
{
	public class MappingConfig
	{
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Student, StudentDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}


