using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StdurmValidator : AbstractValidator<STDURM>
    {
        #region ClientService

        #endregion ClientService

        public StdurmValidator()
        {
            RuleFor(p => p.STDKOD).Length(1,1);
            RuleFor(p => p.STDNAM).Length(1,50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
