namespace ContactList.Business.DTOs;

public record AuthResponseDto(string Token, DateTime Expires, string Email);