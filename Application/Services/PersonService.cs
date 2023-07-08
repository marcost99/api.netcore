using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        { 
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado.");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            if (people.Count == 0)
                return ResultService.Fail<ICollection<PersonDTO>>("Nenhuma pessoa encontrada.");
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail<PersonDTO>("Pessoa não encontrada.");
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }
    }
}
