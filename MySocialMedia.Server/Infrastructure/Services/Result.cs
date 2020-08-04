namespace MySocialMedia.Server.Infrastructure.Services
{
    public class Result
    {
        public bool Succeded { get; private set; }

        public bool Failure => !this.Succeded;

        public string Error { get; private set; }

        public static implicit operator Result(bool succeeded)
            => new Result
            {
                Succeded = succeeded
            };

        public static implicit operator Result(string error)
            => new Result
            {
                Succeded = false,
                Error = error
            };
    }
}
