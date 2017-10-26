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

        void CreateFlashCard(CreateFlashCardRequest request);
    }
}
