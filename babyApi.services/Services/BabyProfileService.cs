using AutoMapper;
using babyApi.data;
using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
using babyApi.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace babyApi.services.Services
{
    public class BabyProfileService : IBabyProfileService
        
    {
        private readonly IBabyProfileRepository _babyProfileRepository;
        
        public BabyProfileService(IBabyProfileRepository babyProfileRepository)
        {

            _babyProfileRepository = babyProfileRepository;
            
          
        }


        public bool Add(BabyProfile model)
        {
           return _babyProfileRepository.Add(model);
        }

        public bool Delete(BabyProfile model)
        {
           return _babyProfileRepository.Delete(model);
        }

        public IEnumerable<BabyProfile> GetAll()
        {
          return _babyProfileRepository.GetAll();
        }

        public IEnumerable<BabyProfile> GetBy(Expression<Func<BabyProfile, bool>> predicate, params Expression<Func<BabyProfile, object>>[] includes)
        {
           return _babyProfileRepository.GetBy(predicate, includes);
        }

        public BabyProfile GetById(int id)
        {
            return _babyProfileRepository.GetById(id);
        }

        public bool Update(BabyProfile model)
        {
            return _babyProfileRepository.Update(model); 
        }
    }


}
