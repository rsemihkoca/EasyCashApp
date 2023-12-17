namespace DtoLayer.Dtos.AppUserDtos
{
    public record AppUserRegisterRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}