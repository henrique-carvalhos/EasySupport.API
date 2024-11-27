using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertCategory
{
    public class InsertCategoryCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public Category ToEntity()
            => new(Name);
    }
}
