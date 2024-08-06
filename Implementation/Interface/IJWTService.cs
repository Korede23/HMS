using HMS.Dto;

namespace HMS.Implementation.Interface
{
    public interface IJWTService
    {
        string JwtWebToken(UserDto user);
    }
}
