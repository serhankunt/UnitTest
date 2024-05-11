namespace RealWorld.WebAPI.DTOs;

public sealed record UpdateUserDto(
    int Id,
    string Name,
    int Age,
    DateOnly DateOfBirth);
