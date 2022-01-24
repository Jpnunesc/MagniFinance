
using AutoMapper;
using Moq;
using Xunit;
using Business.Services;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Domain.Entitys;
using System.Collections.Generic;
using System.Configuration;
using System;
using System.IO;
using Business.IO.Teacher;
using System.Globalization;

namespace Test.Tests.service
{
    public class TeacherTest
    {
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<ITeacherRepository> mockRepository = new Moq.Mock<ITeacherRepository>();
        [Fact(DisplayName = "Carregar arquivo")]
        public async void CadastrarTipoAdministracao_ComDadosCorretos_DeveRetornarCadastrado()
        {
            TeacherService service = new TeacherService(mapper.Object, mockRepository.Object, null);
            var result = await service.Save(new TeacherInput
            { 
                Id = 1, Name ="TEST", 
                Remuneration = 10000, 
                Status = true, 
                BirthDate = new DateTime(new DateTime(1994, 03, 08, 00, 00, 0, new CultureInfo("en-US", false).Calendar).Ticks) 
            });
            Assert.True(result.Status);

        }
    }
}
