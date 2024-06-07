using PharmacyApi.Services;
using PrzykładowyKolos2.DTOs;
using PrzykładowyKolos2.Models;
using PrzykładowyKolos2.Repositories;

namespace PrzykładowyKolos2.Services;

public class WytworniaService : IWytworniaService
{
    private readonly IWytworniaRepository _wytworniaRepository;

    public WytworniaService(IWytworniaRepository wytworniaRepository)
    {
        _wytworniaRepository = wytworniaRepository;
    }

    public async Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken)
    {
        if (!await _wytworniaRepository.DoesMuzykExist(idMuzyk, cancellationToken))
            return null;

        return await _wytworniaRepository.GetMuzyk(idMuzyk, cancellationToken);
    }

    public async Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken)
    {
        return await _wytworniaRepository.AddMuzyk(muzykDto, cancellationToken);
    }
}