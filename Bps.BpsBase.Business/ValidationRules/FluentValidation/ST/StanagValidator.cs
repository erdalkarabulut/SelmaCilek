using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StanagValidator : AbstractValidator<STANAG>
    {
        #region ClientService

        #endregion ClientService

        public StanagValidator()
        {
            RuleFor(p => p.STANAK).Length(1,25).NotNull();
            RuleFor(p => p.STANAN).Length(1,40);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
