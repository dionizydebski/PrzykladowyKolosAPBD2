
using PrzykładowyKolos2.DTOs;
using PrzykładowyKolos2.Models;

namespace PharmacyApi.Services;

public interface IWytworniaService
{
    Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken);
    Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken);
}