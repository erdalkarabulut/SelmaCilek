using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CR
{
    public class CrcafyValidator : AbstractValidator<CRCAFY>
    {
        #region ClientService

        #endregion ClientService

        public CrcafyValidator()
        {
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.STFYNO).Length(1,50).NotNull();
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.VARSAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
