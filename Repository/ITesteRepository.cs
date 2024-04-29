using UplaceApi.Models;


namespace UplaceApi.Repository
{
    public interface ITesteRepository 
    {
        Task<IEnumerable<Teste>> ObterTestes();
    }
}