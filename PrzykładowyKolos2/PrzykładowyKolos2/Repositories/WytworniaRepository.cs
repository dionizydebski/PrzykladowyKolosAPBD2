using Microsoft.EntityFrameworkCore;
using PrzykładowyKolos2.Context;
using PrzykładowyKolos2.DTOs;
using PrzykładowyKolos2.Models;

namespace PrzykładowyKolos2.Repositories;

public class WytworniaRepository : IWytworniaRepository
{
    private readonly ApbdContext _context;

    public WytworniaRepository(ApbdContext context)
    {
        _context = context;
    }
    
    public async Task<MuzykDTO> GetMuzyk(int idMuzyk, CancellationToken cancellationToken)
    {
        MuzykDTO result =  (await _context.Muzycy
            .Where(x => x.IdMuzyk == idMuzyk)
            .Select(m => new MuzykDTO(
                m.Imie,
                m.Nazwisko,
                m.Pseudonim,
                m.Utwor
                    .Select(u => new UtworDTO(
                        u.IdUtwor,
                        u.NazwaUtworu,
                        u.CzasTrwania,
                        u.IdAlbum
                    )).ToList()
            )).FirstOrDefaultAsync(cancellationToken))!;

        return result;
    }

    public async Task<bool> DoesMuzykExist(int idMuzyk, CancellationToken cancellationToken)
    {
        return await _context.Muzycy.Where(x => x.IdMuzyk == idMuzyk).AnyAsync(cancellationToken);
    }

    public async Task<int> AddMuzyk(MuzykDTO muzykDto, CancellationToken cancellationToken)
    {
        if (await _context.Muzycy.Where(x => x.Imie == muzykDto.Imie && x.Nazwisko == muzykDto.Nazwisko).AnyAsync(cancellationToken))
            return 0;

        using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
        {
            var muzyk = new Muzyk
            {
                Imie = muzykDto.Imie,
                Nazwisko = muzykDto.Nazwisko,
                Pseudonim = muzykDto.Pseudonim,
                Utwor = new List<Utwor>()
            };

            foreach (var utworDto in muzykDto.Utwory)
            {
                var utwor = await _context.Utwory
                    .FirstOrDefaultAsync(u => u.IdUtwor == utworDto.IdUtwor, cancellationToken);

                if (utwor == null)
                {
                    utwor = new Utwor
                    {
                        NazwaUtworu = utworDto.NazwaUtworu,
                        CzasTrwania = utworDto.CzasTrwania,
                        IdAlbum = utworDto.IdAlbum
                    };
                    await _context.Utwory.AddAsync(utwor, cancellationToken);
                }

                muzyk.Utwor.Add(utwor);
            }

            await _context.Muzycy.AddAsync(muzyk, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return muzyk.IdMuzyk;
        }
    }
}