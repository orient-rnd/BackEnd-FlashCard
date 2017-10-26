using System;
using System.Collections.Generic;
using System.Text;
using FlashCard.Domains.RequestResponseMessages;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.Models.Domains;
using AutoMapper;
using MongoDB.Driver;

namespace FlashCard.BusinessLogic
{
    public class FlashcardBusinessLogic : IFlashcardBusinessLogic
    {
        private readonly IMongoDbWriteRepository _mongoDbWriteRepository;
        private readonly IMapper _mapper;

        public FlashcardBusinessLogic(IMongoDbWriteRepository mongoDbWriteRepository, IMapper mapper)
        {
            _mongoDbWriteRepository = mongoDbWriteRepository;
            _mapper = mapper;
        }

        public void CreateFlashCardCategory(CreateFlashCardCategoryRequest request)
        {
            var category = _mapper.Map<CreateFlashCardCategoryRequest, FlashCardCategory>(request);
            _mongoDbWriteRepository.Create(category);
        }

        public List<GetFlashCardCategoryResponse> GetFlashCardCategory(GetFlashCardCategoryRequest request)
        {
            var filter = Builders<FlashCardCategory>.Filter.Empty;

            if (!string.IsNullOrEmpty(request.Id))
            {
                filter = filter & Builders<FlashCardCategory>.Filter.Where(n => n.Id == request.Id);
            }

            var cates = _mongoDbWriteRepository.Find(filter).ToList();
            var responseCates = _mapper.Map<List<FlashCardCategory>, List<GetFlashCardCategoryResponse>>(cates);
            return responseCates;
        }

        public void UpdateFlashCardCategory(UpdateFlashCardCategoryRequest request)
        {
            var cate = _mapper.Map<UpdateFlashCardCategoryRequest, FlashCardCategory>(request);
            _mongoDbWriteRepository.Replace(cate);
        }

        public void DeleteFlashCardCategory(DeleteFlashCardCategoryRequest request)
        {
            var catef = _mapper.Map<DeleteFlashCardCategoryRequest, FlashCardCategory>(request);
            _mongoDbWriteRepository.Delete(catef);
        }

        public void CreateFlashCard(CreateFlashCardRequest request)
        {
            var flashCard = _mapper.Map<CreateFlashCardRequest, FlashCards>(request);
            _mongoDbWriteRepository.Create(flashCard);
        }
    }
}