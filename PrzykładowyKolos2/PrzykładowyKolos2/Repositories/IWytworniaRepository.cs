
using PrzykładowyKolos2.DTOs;
using PrzykładowyKolos2.Enums;
using PrzykładowyKolos2.Models;

namespace PrzykładowyKolos2.Repositories;

public interface IWytworniaRepository
{
    Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken);
    Task<bool> DoesMuzykExist(int idMuzyk, CancellationToken cancellationToken);
    Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken);
}