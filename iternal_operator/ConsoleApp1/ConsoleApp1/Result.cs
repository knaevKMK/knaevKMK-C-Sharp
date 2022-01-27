namespace ConsoleApp1
{
    using System.Collections.Generic;
    public class Result<TEntityViewModel>
    {
        public bool Succeeded { get; private set; }
        public bool Failure => !this.Succeeded;
        public TEntityViewModel Data { get; private set; }
        public string Message { get; set; }
        //=> string.Format("{0}: {1}"
        //    , Succeeded ? nameof(Succeeded) : nameof(Failure)
        //    , Succeeded ? nameof(TEntityViewModel) : string.Join("\n\t", this.Errors)
        //   );
        public ICollection<ErrorEnum> Errors { get; private set; } = new List<ErrorEnum>();

        public override string ToString()
        {
            return
                "Msg:\t" + this.Message +
                "\n\tSuccessud:\t" + this.Succeeded +
                "\n\tFailer:\t" + this.Failure +
                "\n\tData:\t" + this.Data +
                "\n\tErrors:\n\t\t" + string.Join("\n\t\t", this.Errors);
        }


        public static implicit operator Result<TEntityViewModel>(object[] args)
           => new() { 
               Succeeded =  (bool)args[0],
               Data=(TEntityViewModel)args[1],
               Message=(string)args[2],
               Errors=(List<ErrorEnum>)args[3]
           };

        public static implicit operator Result<TEntityViewModel>(bool succeeded)
            => new() { Succeeded = succeeded };
        public static implicit operator Result<TEntityViewModel>(TEntityViewModel data)
          => new()
          {
              Succeeded = true,
              Data = data
          };
        public static implicit operator Result<TEntityViewModel>(List<ErrorEnum> errors)
            => new() { Errors = errors };
        public static implicit operator Result<TEntityViewModel>(string errorMsg)
           => new() { Message = errorMsg };

    }
}
