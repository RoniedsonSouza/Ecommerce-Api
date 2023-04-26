using MediatR;

namespace Application.Commands.Categorias
{
    public class AdicionarCategoriaCommand : IRequest<Application.ADTO.Categoria>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
