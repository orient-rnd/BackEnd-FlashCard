using AutoMapper;
using FlashCard.Domains.RequestResponseMessages;
using FlashCard.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcard.AppServices.APIs.Configs
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateFlashCardCategoryRequest, FlashCardCategory>();
                cfg.CreateMap<FlashCardCategory, GetFlashCardCategoryResponse>();
                cfg.CreateMap<CreateFlashCardRequest, FlashCards>();
                cfg.CreateMap<FlashCards, GetFlashCardResponse>();
            });
            return config;
        }
    }
}