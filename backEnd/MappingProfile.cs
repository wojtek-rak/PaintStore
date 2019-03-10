using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PaintStore.Domain.Entities;
using PaintStore.Domain.InputModels;

namespace PaintStore.BackEnd
{
    public class MappingProfile : Profile {  
        public MappingProfile()
        {
            CreateMap<AddPostCommentCommand, PostComments>();
        }  
    }  
}
