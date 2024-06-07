namespace PrzykładowyKolos2.DTOs;

public record MuzykDTO(string Imie, string Nazwisko, string? Pseudonim, List<UtworDTO> Utwory);