using FlashCard.Domains.RequestResponseMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCard.BusinessLogic
{
    public interface IFlashcardBusinessLogic
    {
        void CreateFlashCardCategory(CreateFlashCardCategoryRequest request);

        List<GetFlashCardCategoryResponse> GetFlashCardCategory(GetFlashCardCategoryRequest request);

        void UpdateFlashCardCategory(UpdateFlashCardCategoryRequest request);

        void DeleteFlashCardCategory(DeleteFlashCardCategoryRequest request);
        void DeleteFlashCard(DeleteFlashCardRequest request);
        void CreateFlashCard(CreateFlashCardRequest request);

        void UpdateFlashCard(UpdateFlashCardRequest request);

        List<GetFlashCardResponse> GetFlashCard(GetFlashCardRequest request);
        List<GetFlashCardResponse> GetFlashCardByCategoryId(GetFlashCardRequest request);
    }
}
