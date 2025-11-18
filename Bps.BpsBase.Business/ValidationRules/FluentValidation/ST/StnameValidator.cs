using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StnameValidator : AbstractValidator<STNAME>
    {
        #region ClientService

        #endregion ClientService

        public StnameValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.LANGKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
