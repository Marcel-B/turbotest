namespace com.marcelbenders.Aqua.Api.Dto;



public record User(
    string DisplayName,
    string Token,
    string Username,
    string Image);
